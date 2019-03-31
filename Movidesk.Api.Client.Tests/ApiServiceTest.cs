using Microsoft.Extensions.Configuration;
using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Enums;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Movidesk.Api.Client.Tests
{
    public class ApiServiceTest : BaseTest
    {

        private readonly MovideskApiClientOptions _options;

        public ApiServiceTest()
        {
            _options = new MovideskApiClientOptions { Token = Token };
        }

        [Fact]
        public void GetByIdTest()
        {
            var client = new ServicesClient(_options);
            var result = client.Get(8667).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public void GetAllTest()
        {
            var client = new ServicesClient(_options);
            var result = client.Get().Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Service>>(result.ResponseObject);
        }

        [Fact]
        public void PostTest()
        {
            var client = new ServicesClient(_options);
            var result = client.Post(GetFakeService()).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public void PostFailtTest()
        {
            var client = new ServicesClient(_options);
            var result = client.Post(new Service { }).Result;

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
            Assert.Null(result.ResponseObject);
        }

        [Fact]
        public void PatchTest()
        {
            var client = new ServicesClient(_options);

            var postResult = client.Post(GetFakeService()).Result;
            Assert.True(postResult.InnerResponse.IsSuccessStatusCode);
            Assert.True(postResult.ResponseObject.Id.HasValue);

            var result = client.Patch(postResult.ResponseObject.Id.Value, new { name = "Another name" }).Result;

            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public void DeleteTest()
        {
            var client = new ServicesClient(_options);

            var postResult = client.Post(GetFakeService()).Result;

            var result = client.Delete(postResult.ResponseObject.Id.Value).Result;

            Assert.True(result.IsSuccessStatusCode);
        }

        private Service GetFakeService()
        {
            return new Service
            {
                Name = "Nome",
                Description = "Description",
                IsVisible = ServiceVisibility.AgentAndClient,
                ServiceForTicketType = TicketType.PublicAndIntern,
                AllowSelection = ServiceSelection.AgentAndClient,
                AllowFinishTicket = true,
                IsActive = true,
                AllowAllCategories = true
            };
        }
    }
}
