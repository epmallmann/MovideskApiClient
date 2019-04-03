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
    public class PersonResource : IPersonResource
    {
        private readonly IMovideskApiClient _apiClient;

        public PersonResource(IMovideskApiClient apiClient)
        {
            _apiClient = apiClient;
            _apiClient.Configure("/persons");
        }

        public async Task<HttpResponseMessage> Delete(string id)
        {
            var result = await _apiClient.Delete(id);
            return result;
        }

        public async Task<ApiResponse<List<Person>>> Get(OData odata = null)
        {
            var result = await _apiClient.Get<List<Person>>(odata?.ToString());
            return result;
        }

        public async Task<ApiResponse<Person>> GetById(string id)
        {
            var result = await _apiClient.Get<Person>($"&id={id}");
            return result;
        }

        public async Task<HttpResponseMessage> Patch(string id, Person person)
        {
            var result = await _apiClient.Patch($"&id={id}", person);
            return result;
        }

        public async Task<ApiResponse<Person>> Post(Person person, bool returnAllProperties = false)
        {
            var result = await _apiClient.Post<Person>($"&returnAllProperties={returnAllProperties}", person);
            return result;
        }
    }
}
