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
        public void GetByNameTest()
        {
            var client = GetClient();
            var result = client.TimeAgreements.GetByName("contrato").Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.Equal("Contrato", result.ResponseObject.Name);
        }

        [Fact]
        public async Task NotNullODataGetTest()
        {
            var client = GetClient();

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => client.TimeAgreements.Get(null));
            var expectedMessage = @"odata cannot be null
Parameter name: odata";
            Assert.Equal(expectedMessage, exception.Message);

            exception = await Assert.ThrowsAsync<ArgumentNullException>(() => client.TimeAgreements.Get(new OData { }));
            expectedMessage = @"odata.select must be informed for this method
Parameter name: odata";
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void GetListTest()
        {
            var client = GetClient();
            var result = client.TimeAgreements.Get(new OData { Select = "name" }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.True(result.ResponseObject.Count > 0);
        }

        [Fact]
        public void PostFailTest()
        {
            var client = GetClient();
            var result = client.TimeAgreements.Post(new TimeAgreement { }).Result;

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
            Assert.Null(result.ResponseObject);
        }

        [Fact]
        public void SimplePostTest()
        {
            var client = GetClient();
            var result = client.TimeAgreements.Post(GetFakeTimeAgreement()).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
        }

        [Fact]
        public void SimplePatchTest()
        {
            var client = GetClient();
            var timeAgreement = GetFakeTimeAgreement();

            var resultPost = client.TimeAgreements.Post(timeAgreement).Result;

            Assert.True(resultPost.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(resultPost.ResponseObject);

            var result = client.TimeAgreements.Patch(timeAgreement.Name, new TimeAgreement { RenewalDay = 30 }).Result;

            Assert.True(result.IsSuccessStatusCode);
        }
        
        [Fact]
        public void DeleteTest()
        {
            var client = GetClient();
            var timeAgreement = GetFakeTimeAgreement();

            var resultPost = client.TimeAgreements.Post(timeAgreement).Result;

            Assert.True(resultPost.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(resultPost.ResponseObject);

            var result = client.TimeAgreements.Delete(timeAgreement.Name).Result;
            Assert.True(result.IsSuccessStatusCode);
        }

        private MovideskClient GetClient() => new MovideskClient(new MovideskApiClient(_options));

        private TimeAgreement GetFakeTimeAgreement()
        {
            return new TimeAgreement
            {
                Name = $"test_{Guid.NewGuid().ToString()}",
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
                        Id = "72100171"
                    }
                }
            };
        }
    }
}
