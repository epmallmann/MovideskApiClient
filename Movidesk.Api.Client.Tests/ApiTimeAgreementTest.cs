using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
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

        private MovideskClient GetClient() => new MovideskClient(new MovideskApiClient(_options));
    }
}
