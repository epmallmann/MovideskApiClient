using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Movidesk.Api.Client.Tests
{
    public class ApiPersonTest : BaseTest
    {
        private readonly MovideskApiClientOptions _options;

        public ApiPersonTest()
        {
            _options = new MovideskApiClientOptions { Token = Token };
        }

        [Fact]
        public void GetAllTest()
        {
            var client = new PersonsClient(_options);
            var result = client.Get().Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Person>>(result.ResponseObject);
        }

        [Fact]
        public void GetODataTop1Test()
        {
            var client = new PersonsClient(_options);
            var result = client.Get(new OData { Top = 1 }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Person>>(result.ResponseObject);
            Assert.True(result.ResponseObject.Count == 1);
        }

        [Fact]
        public void GetODataSelectTest()
        {
            var client = new PersonsClient(_options);
            var result = client.Get(new OData { Select = "corporateName,id" }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Person>>(result.ResponseObject);
            Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.BusinessName));
        }

        [Fact]
        public void PostTest()
        {
            var client = new PersonsClient(_options);
            var result = client.Post(GetFakePerson()).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
        }

        [Fact]
        public void PostFailTest()
        {
            var client = new PersonsClient(_options);
            var result = client.Post(new Person { }).Result;

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
        }

        private Person GetFakePerson()
        {
            return new Person
            {
                BusinessName = $"test_{Guid.NewGuid().ToString()}",
                ProfileType = Enums.ProfileType.Agent,
                PersonType = Enums.PersonType.Person,
                IsActive = true,
                AccessProfile = "Agentes",
                Teams = new List<string> { "Agentes" }
            };
        }
    }
}
