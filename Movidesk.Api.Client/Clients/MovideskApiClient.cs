using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Clients
{
    public class MovideskApiClient
    {
        private readonly string _token;
        private readonly string _apiUrl = "https://api.movidesk.com/public/v1";
        private string _baseUrl;

        public MovideskApiClient(MovideskApiClientOptions options, string url)
        {
            _token = options.Token;
            _baseUrl = _apiUrl + url;
        }

        internal async Task<ApiResponse<T>> Get<T>() where T : class
        {
            return await Get<T>(string.Empty);
        }

        internal async Task<ApiResponse<T>> Get<T>(string query) where T : class
        {
            var url = $"{_baseUrl}?token={_token}{query??string.Empty}";

            var client = new BaseClient();
            var result = await client.BaseGet<T>(url);

            return result;
        }

        internal async Task<ApiResponse<T>> Post<T>(object content) where T : class
        {
            return await Post<T>(string.Empty, content);
        }

        internal async Task<ApiResponse<T>> Post<T>(string query, object content) where T : class
        {
            var url = $"{_baseUrl}?token={_token}{query}";

            var client = new BaseClient();
            var result = await client.BasePost<T>(url, content);

            return result;
        }

        internal async Task<HttpResponseMessage> Patch(string query, object content)
        {
            var url = $"{_baseUrl}?token={_token}{query}";

            var client = new BaseClient();
            var result = await client.BasePatch(url, content);

            return result;
        }

        internal async Task<HttpResponseMessage> Delete(int id)
        {
            var url = $"{_baseUrl}?token={_token}&id={id}";

            var client = new BaseClient();
            var result = await client.BaseDelete(url);

            return result;
        }
    }
}
