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
    public class ServicesResource : IServicesResource
    {
        private readonly IMovideskApiClient _apiClient;

        public ServicesResource(IMovideskApiClient apiClient)
        {
            _apiClient = apiClient;
            _apiClient.Configure("/services");
        }

        public async Task<ApiResponse<List<Service>>> Get(OData odata = null)
        {
            var result = await _apiClient.Get<List<Service>>(odata?.ToString());
            return result;
        }

        public async Task<ApiResponse<Service>> GetById(int id)
        {
            var result = await _apiClient.Get<Service>($"&id={id}");
            return result;
        }

        public async Task<ApiResponse<Service>> Post(Service service, bool returnAllProperties = false)
        {
            var result = await _apiClient.Post<Service>($"&returnAllProperties={returnAllProperties}", service);
            return result;
        }

        public async Task<HttpResponseMessage> Patch(int id, Service service)
        {
            var result = await _apiClient.Patch($"&id={id}", service);
            return result;
        }

        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await _apiClient.Delete(id);
            return result;
        }
    }
}
