using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;

namespace Movidesk.Api.Client.Resources
{
    public class TimeAgreementResource : ITimeAgreementResource
    {
        private readonly IMovideskApiClient _client;

        public TimeAgreementResource(IMovideskApiClient client)
        {
            _client = client;
            _client.Configure("/timeAgreement");
        }

        public async Task<HttpResponseMessage> Delete(string name)
        {
            var result = await _client.Delete(name, "name");
            return result;
        }

        public async Task<ApiResponse<List<TimeAgreement>>> Get(OData odata)
        {
            if (odata == null)
                throw new ArgumentNullException("odata", "odata cannot be null");
            if (string.IsNullOrEmpty(odata.Select))
                throw new ArgumentNullException("odata.select must be informed for this method");

            var result = await _client.Get<List<TimeAgreement>>(odata.ToString());
            return result;
        }

        public async Task<ApiResponse<TimeAgreement>> GetByName(string name)
        {
            var result = await _client.Get<TimeAgreement>($"&name={name}");
            return result;
        }

        public async Task<HttpResponseMessage> Patch(string name, TimeAgreement timeAgreement)
        {
            var result = await _client.Patch($"&name={name}", timeAgreement);
            return result;
        }

        public Task<ApiResponse<TimeAgreement>> Post(TimeAgreement timeAgreement)
        {
            var result = _client.Post<TimeAgreement>(string.Empty, timeAgreement);
            return result;
        }
    }
}
