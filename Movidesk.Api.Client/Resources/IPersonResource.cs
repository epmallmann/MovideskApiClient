using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Resources
{
    public interface IPersonResource
    {
        Task<ApiResponse<Person>> GetById(string id);

        Task<ApiResponse<List<Person>>> Get(OData odata = null);

        Task<ApiResponse<Person>> Post(Person person, bool returnAllProperties = false);

        Task<HttpResponseMessage> Patch(string id, Person person);

        Task<HttpResponseMessage> Delete(string id);
    }
}