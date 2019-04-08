using Movidesk.Api.Client.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Clients
{
    public interface IMovideskApiClient
    {
        void Configure(string resource);

        Task<ApiResponse<T>> Get<T>(string query) where T : class;

        Task<ApiResponse<T>> Post<T>(string query, object content) where T : class;

        Task<HttpResponseMessage> Patch(string query, object content);

        Task<HttpResponseMessage> Delete(object id, string field = "id");
    }
}