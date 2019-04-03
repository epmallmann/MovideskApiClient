using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Enums;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
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
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = client.Services.GetById(8667).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public void GetAllTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = client.Services.Get().Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Service>>(result.ResponseObject);
        }

        [Fact]
        public void GetODataTop1Test()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = client.Services.Get(new OData { Top = 1 }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Service>>(result.ResponseObject);
            Assert.True(result.ResponseObject.Count == 1);
        }

        [Fact]
        public void GetODataSelectTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = client.Services.Get(new OData { Select = "name,id" }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Service>>(result.ResponseObject);
            Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.Description));
        }

        [Fact]
        public void PostTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));

            var service = GetFakeService();

            var result = client.Services.Post(service).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public void PostReturnAllPropertiesTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = client.Services.Post(GetFakeService(), returnAllProperties: true).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public void PostFailtTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = client.Services.Post(new Service { }).Result;

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
            Assert.Null(result.ResponseObject);
        }

        [Fact]
        public void PatchTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));

            var postResult = client.Services.Post(GetFakeService()).Result;
            Assert.True(postResult.InnerResponse.IsSuccessStatusCode);
            Assert.True(postResult.ResponseObject.Id.HasValue);

            var result = client.Services.Patch(postResult.ResponseObject.Id.Value, new Service { Name = $"test2_{Guid.NewGuid().ToString()}" }).Result;

            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public void DeleteTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));

            var postResult = client.Services.Post(GetFakeService()).Result;

            Assert.True(postResult.ResponseObject.Id.HasValue);

            var deleteResult = client.Services.Delete(postResult.ResponseObject.Id.Value).Result;

            Assert.True(deleteResult.IsSuccessStatusCode);

            var getResult = client.Services.GetById(postResult.ResponseObject.Id.Value).Result;

            Assert.False(getResult.InnerResponse.IsSuccessStatusCode);
            Assert.True(getResult.InnerResponse.StatusCode == System.Net.HttpStatusCode.NotFound);
            Assert.Null(getResult.ResponseObject);
        }

        private Service GetFakeService()
        {
            return new Service
            {
                Name = $"test_{Guid.NewGuid().ToString()}",
                Description = "Description",
                IsVisible = ServiceVisibility.AgentAndClient,
                ServiceForTicketType = ServiceTicketType.PublicAndInternal,
                AllowSelection = ServiceSelection.AgentAndClient,
                AllowFinishTicket = true,
                IsActive = true,
                AllowAllCategories = true
            };
        }
    }
}
