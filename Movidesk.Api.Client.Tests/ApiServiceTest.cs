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
        public async void GetByIdTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = await client.Services.GetById(1024668);

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public async void GetAllTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = await client.Services.Get();

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Service>>(result.ResponseObject);
        }

        [Fact]
        public async void GetODataTop1Test()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = await client.Services.Get(new OData { Top = 1 });

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Service>>(result.ResponseObject);
            Assert.True(result.ResponseObject.Count == 1);
        }

        [Fact]
        public async void GetODataSelectTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = await client.Services.Get(new OData { Select = "name,id" });

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<List<Service>>(result.ResponseObject);
            Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.Description));
        }

        [Fact]
        public async void PostTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));

            var service = GetFakeService();

            var result = await client.Services.Post(service);

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public async void PostReturnAllPropertiesTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = await client.Services.Post(GetFakeService(), returnAllProperties: true);

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.IsType<Service>(result.ResponseObject);
        }

        [Fact]
        public async void PostFailtTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));
            var result = await client.Services.Post(new Service { });

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
            Assert.Null(result.ResponseObject);
        }

        [Fact]
        public async void PatchTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));

            var postResult = await client.Services.Post(GetFakeService());
            Assert.True(postResult.InnerResponse.IsSuccessStatusCode);
            Assert.True(postResult.ResponseObject.Id.HasValue);

            var result = await client.Services.Patch(postResult.ResponseObject.Id.Value, new Service { Name = $"test2_{Guid.NewGuid().ToString()}" });

            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public async void DeleteTest()
        {
            var client = new MovideskClient(new MovideskApiClient(_options));

            var postResult = await client.Services.Post(GetFakeService());

            Assert.True(postResult.ResponseObject.Id.HasValue);

            var deleteResult = await client.Services.Delete(postResult.ResponseObject.Id.Value);

            Assert.True(deleteResult.IsSuccessStatusCode);

            var getResult = await client.Services.GetById(postResult.ResponseObject.Id.Value);

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
