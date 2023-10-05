using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movidesk.Api.Client.Tests
{
    public class ApiTimeAgreementTest : BaseTest
    {
        private readonly MovideskApiClientOptions _options;

        public ApiTimeAgreementTest()
        {
            _options = new MovideskApiClientOptions { Token = Token };
        }

        [Fact]
        public async void GetByNameTest()
        {
            var client = GetClient();
            var result = await client.TimeAgreements.GetByName("contrato");

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.Equal("contrato", result.ResponseObject.Name);
        }

        [Fact]
        public async Task NotNullODataGetTest()
        {
            var client = GetClient();

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => client.TimeAgreements.Get(null));
            var expectedMessage = @"odata cannot be null (Parameter 'odata')";
            Assert.Equal(expectedMessage, exception.Message);

            exception = await Assert.ThrowsAsync<ArgumentNullException>(() => client.TimeAgreements.Get(new OData { }));
            expectedMessage = @"odata.select must be informed for this method (Parameter 'odata')";
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public async void GetListTest()
        {
            var client = GetClient();
            var result = await client.TimeAgreements.Get(new OData { Select = "name" });

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.True(result.ResponseObject.Count > 0);
        }

        [Fact]
        public async void PostFailTest()
        {
            var client = GetClient();
            var result = await client.TimeAgreements.Post(new TimeAgreement { });

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
            Assert.Null(result.ResponseObject);
        }

        [Fact]
        public async void SimplePostTest()
        {
            var client = GetClient();
            var result = await client.TimeAgreements.Post(GetFakeTimeAgreement());

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
        }

        [Fact]
        public async void SimplePatchTest()
        {
            var client = GetClient();
            var timeAgreement = GetFakeTimeAgreement();

            var resultPost = await client.TimeAgreements.Post(timeAgreement);

            Assert.True(resultPost.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(resultPost.ResponseObject);

            var result = await client.TimeAgreements.Patch(timeAgreement.Name, new TimeAgreement { RenewalDay = 30 });

            Assert.True(result.IsSuccessStatusCode);
        }
        
        [Fact]
        public async void DeleteTest()
        {
            var client = GetClient();
            var timeAgreement = GetFakeTimeAgreement();

            var resultPost = await client.TimeAgreements.Post(timeAgreement);

            Assert.True(resultPost.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(resultPost.ResponseObject);

            var result = await client.TimeAgreements.Delete(timeAgreement.Name);
            Assert.True(result.IsSuccessStatusCode);
        }

        private MovideskClient GetClient() => new MovideskClient(new MovideskApiClient(_options));

        private TimeAgreement GetFakeTimeAgreement()
        {
            return new TimeAgreement
            {
                Name = $"test_{Guid.NewGuid()}",
                DifferentiateHoursFranchise = false,
                DifferentiateHoursConsumption = false,
                AccumulateUnusedHours = true,
                RenewalDay = 20,
                BaseAmount = 0,
                ContractedHours = 20,
                IsActive = true,
                TypeActivities = new List<TimeAgreementTypeActivity>
                {
                    new TimeAgreementTypeActivity
                    {
                        
                    }
                },
                Clients = new List<TimeAgreementClient>
                {
                    new TimeAgreementClient
                    {
                        Id = "870921924"
                    }
                }
            };
        }
    }
}
