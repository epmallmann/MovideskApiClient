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
        //private readonly MovideskApiClientOptions _options;

        //public ApiPersonTest()
        //{
        //    _options = new MovideskApiClientOptions { Token = Token };
        //}

        //[Fact]
        //public void GetAllTest()
        //{
        //    var client = new PersonsClient(_options);
        //    var result = client.Get().Result;

        //    Assert.True(result.InnerResponse.IsSuccessStatusCode);
        //    Assert.IsType<List<Person>>(result.ResponseObject);
        //}

        //[Fact]
        //public void GetODataTop1Test()
        //{
        //    var client = new PersonsClient(_options);
        //    var result = client.Get(new OData { Top = 1 }).Result;

        //    Assert.True(result.InnerResponse.IsSuccessStatusCode);
        //    Assert.IsType<List<Person>>(result.ResponseObject);
        //    Assert.True(result.ResponseObject.Count == 1);
        //}

        //[Fact]
        //public void GetODataSelectTest()
        //{
        //    var client = new PersonsClient(_options);
        //    var result = client.Get(new OData { Select = "corporateName,id" }).Result;

        //    Assert.True(result.InnerResponse.IsSuccessStatusCode);
        //    Assert.IsType<List<Person>>(result.ResponseObject);
        //    Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.BusinessName));
        //}

        //[Fact]
        //public void SimplePostTest()
        //{
        //    var client = new PersonsClient(_options);
        //    var result = client.Post(GetFakePerson()).Result;

        //    Assert.True(result.InnerResponse.IsSuccessStatusCode);
        //    Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));
        //}

        //[Fact]
        //public void CompletePostTest()
        //{
        //    var client = new PersonsClient(_options);
        //    var person = GetCompleteFakePerson();
        //    var result = client.Post(person).Result;

        //    var json = JsonConvert.SerializeObject(person);

        //    Assert.True(result.InnerResponse.IsSuccessStatusCode);
        //    Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));
        //}

        //[Fact]
        //public void PostFailTest()
        //{
        //    var client = new PersonsClient(_options);
        //    var result = client.Post(new Person { }).Result;

        //    Assert.False(result.InnerResponse.IsSuccessStatusCode);
        //}

        //[Fact]
        //public void PatchTest()
        //{
        //    var client = new PersonsClient(_options);
        //    var result = client.Post(GetFakePerson()).Result;

        //    Assert.True(result.InnerResponse.IsSuccessStatusCode);
        //    Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));

        //    var result2 = client.Patch(result.ResponseObject.Id, new Person { BusinessName = $"test2_{Guid.NewGuid().ToString()}" }).Result;
        //    Assert.True(result2.IsSuccessStatusCode);
        //}

        //[Fact]
        //public void DeleteTest()
        //{
        //    var client = new PersonsClient(_options);
        //    var result = client.Post(GetFakePerson()).Result;

        //    Assert.True(result.InnerResponse.IsSuccessStatusCode);
        //    Assert.True(!string.IsNullOrEmpty(result.ResponseObject.Id));

        //    var result2 = client.Delete(result.ResponseObject.Id).Result;
        //    Assert.True(result2.IsSuccessStatusCode);
        //}

        //private Person GetFakePerson()
        //{
        //    return new Person
        //    {
        //        BusinessName = $"test_{Guid.NewGuid().ToString()}",
        //        ProfileType = Enums.ProfileType.Agent,
        //        PersonType = Enums.PersonType.Person,
        //        IsActive = true,
        //        AccessProfile = "Agentes",
        //        Teams = new List<string> { "Agentes" }
        //    };
        //}

        //private Person GetCompleteFakePerson()
        //{
        //    return new Person
        //    {
        //        BusinessName = $"test_{Guid.NewGuid().ToString()}",
        //        ProfileType = Enums.ProfileType.Agent,
        //        PersonType = Enums.PersonType.Person,
        //        IsActive = true,
        //        AccessProfile = "Agentes",
        //        Teams = new List<string> { "Agentes" },
        //        UserName = Guid.NewGuid().ToString(),
        //        Password = "z7Qk2Q9BOF",
        //        CpfCnpj = "79941914958",
        //        Observations = "xpto 123 acme lorem",
        //        Addresses = new List<PersonAddress>
        //        {
        //            new PersonAddress {
        //                IsDefault = false,
        //                Street = "Avenida Getúlio Vargas 678 Sala 01",
        //                AddressType = "Comercial",
        //                City = "Abelardo Luz",
        //                State = "Santa Catarina",
        //                District = "Centro",
        //                Number = "399",
        //                PostalCode = "89830-970"
        //            }
        //        },
        //        Contacts = new List<PersonContact> {
        //            new PersonContact { Contact = "(49) 2876-4846", ContactType = "Telefone" },
        //            new PersonContact { Contact = "teste", ContactType = "Skype" }
        //        },
        //        Emails = new List<PersonEmail>
        //        {
        //            new PersonEmail { Email = "eenzoeduardoviana@rodomen.com.br", EmailType = "Pessoal" },
        //            new PersonEmail { Email = "mateusluisfernandes_@webin.com.br", EmailType = "Profissional" },
        //        }
        //    };
        //}
    }
}
