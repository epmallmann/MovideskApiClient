using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using Newtonsoft.Json;
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
            var client = GetClient();
            var result = client.Persons.Get().Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Person>>(result.ResponseObject);
        }

        [Fact]
        public void GetByIdTest()
        {
            var client = GetClient();
            var result = client.Persons.GetById("539639646").Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.Equal("539639646", result.ResponseObject.Id);
        }

        [Fact]
        public void GetODataTop1Test()
        {
            var client = GetClient();
            var result = client.Persons.Get(new OData { Top = 1 }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Person>>(result.ResponseObject);
            Assert.True(result.ResponseObject.Count == 1);
        }

        [Fact]
        public void GetODataSelectTest()
        {
            var client = GetClient();
            var result = client.Persons.Get(new OData { Select = "corporateName,id" }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Person>>(result.ResponseObject);
            Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.BusinessName));
        }

        [Fact]
        public void SimplePostTest()
        {
            var client = GetClient();
            var result = client.Persons.Post(GetFakePerson()).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));
        }

        [Fact]
        public void CompletePostTest()
        {
            var client = GetClient();
            var person = GetCompleteFakePerson();
            var result = client.Persons.Post(person).Result;

            var json = JsonConvert.SerializeObject(person);

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));
        }

        [Fact]
        public void PostFailTest()
        {
            var client = GetClient();
            var result = client.Persons.Post(new Person { }).Result;

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
        }

        [Fact]
        public void PatchTest()
        {
            var client = GetClient();
            var result = client.Persons.Post(GetFakePerson()).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));

            var result2 = client.Persons.Patch(result.ResponseObject.Id, new Person { BusinessName = $"test2_{Guid.NewGuid().ToString()}" }).Result;
            Assert.True(result2.IsSuccessStatusCode);
        }

        [Fact]
        public void DeleteTest()
        {
            var client = GetClient();
            var result = client.Persons.Post(GetFakePerson()).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));

            var result2 = client.Persons.Delete(result.ResponseObject.Id).Result;
            Assert.True(result2.IsSuccessStatusCode);
        }

        private MovideskClient GetClient() => new MovideskClient(new MovideskApiClient(_options));


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

        private Person GetCompleteFakePerson()
        {
            return new Person
            {
                BusinessName = $"test_{Guid.NewGuid().ToString()}",
                ProfileType = Enums.ProfileType.Agent,
                PersonType = Enums.PersonType.Person,
                IsActive = true,
                AccessProfile = "Agentes",
                Teams = new List<string> { "Agentes" },
                UserName = Guid.NewGuid().ToString(),
                Password = "z7Qk2Q9BOF",
                CpfCnpj = "79941914958",
                Observations = "xpto 123 acme lorem",
                Addresses = new List<PersonAddress>
                {
                    new PersonAddress {
                        IsDefault = false,
                        Street = "Avenida Getúlio Vargas 678 Sala 01",
                        AddressType = "Comercial",
                        City = "Abelardo Luz",
                        State = "Santa Catarina",
                        District = "Centro",
                        Number = "399",
                        PostalCode = "89830-970"
                    }
                },
                Contacts = new List<PersonContact> {
                    new PersonContact { Contact = "(49) 2876-4846", ContactType = "Telefone" },
                    new PersonContact { Contact = "teste", ContactType = "Skype" }
                },
                Emails = new List<PersonEmail>
                {
                    new PersonEmail { Email = "eenzoeduardoviana@rodomen.com.br", EmailType = "Pessoal" },
                    new PersonEmail { Email = "mateusluisfernandes_@webin.com.br", EmailType = "Profissional" },
                }
            };
        }
    }
}
