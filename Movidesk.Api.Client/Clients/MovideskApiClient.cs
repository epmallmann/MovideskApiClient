using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Clients
{
    public class MovideskApiClient : IMovideskApiClient
    {
        private readonly string _token;
        private readonly string _apiUrl = "https://api.movidesk.com/public/v1";
        private string _baseUrl;

        public MovideskApiClient(MovideskApiClientOptions options)
        {
            _token = options.Token;
        }

        public void Configure(string resource)
        {
            _baseUrl = _apiUrl + resource;
        }

        public async Task<ApiResponse<T>> Get<T>(string query) where T : class
        {
            var requestUri = $"{_baseUrl}?token={_token}{query ?? string.Empty}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(requestUri);
                var content = await response.Content.ReadAsStringAsync();

                var result = new ApiResponse<T>
                {
                    InnerResponse = response,
                    ResponseObject = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(content) : null
                };

                return result;
            }
        }

        public async Task<ApiResponse<T>> Post<T>(string query, object content) where T : class
        {
            var requestUri = $"{_baseUrl}?token={_token}{query}";

            using (var httpClient = new HttpClient())
            {
                var contentJson = JsonConvert.SerializeObject(content);

                var response = await httpClient.PostAsync(requestUri, new StringContent(contentJson, Encoding.UTF8, "application/json"));
                var contentResult = await response.Content.ReadAsStringAsync();

                var result = new ApiResponse<T>
                {
                    InnerResponse = response,
                    ResponseObject = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(contentResult) : null
                };

                return result;
            }
        }

        public async Task<HttpResponseMessage> Patch(string query, object content)
        {
            var requestUri = $"{_baseUrl}?token={_token}{query}";

            using (var httpClient = new HttpClient())
            {
                var contentJson = JsonConvert.SerializeObject(content);
                var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
                {
                    Content = new StringContent(contentJson, Encoding.UTF8, "application/json")
                };
                var response = await httpClient.SendAsync(request);

                return response;
            }
        }

        public async Task<HttpResponseMessage> Delete(object id)
        {
            var requestUri = $"{_baseUrl}?token={_token}&id={id}";
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(requestUri);
                return response;
            }
        }
    }
}
