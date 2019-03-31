using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Clients
{
    public class BaseClient
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public BaseClient()
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        public async Task<ApiResponse<T>> BaseGet<T>(string requestUri) where T : class
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(requestUri);
            var content = await response.Content.ReadAsStringAsync();

            var result = new ApiResponse<T>
            {
                InnerResponse = response,
                ResponseObject = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(content, _jsonSerializerSettings) : null
            };

            return result;
        }

        public async Task<ApiResponse<T>> BasePost<T>(string requestUri, object content) where T : class
        {
            var httpClient = new HttpClient();

            var response = await httpClient.PostAsJsonAsync(requestUri, content);
            var contentResult = await response.Content.ReadAsStringAsync();

            var result = new ApiResponse<T>
            {
                InnerResponse = response,
                ResponseObject = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(contentResult, _jsonSerializerSettings) : null
            };

            return result;
        }

        public async Task<HttpResponseMessage> BasePatch(string requestUri, object content)
        {
            var httpClient = new HttpClient();

            var contentJson = JsonConvert.SerializeObject(content);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
            {
                Content = new StringContent(contentJson, Encoding.GetEncoding("iso-8859-1"), "application/json")
            };
            var response = await httpClient.SendAsync(request);

            return response;
        }

        public async Task<HttpResponseMessage> BaseDelete(string requestUri)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(requestUri);

            return response;
        }
    }
}
