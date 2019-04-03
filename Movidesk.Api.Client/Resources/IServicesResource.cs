using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Resources
{
    public interface IServicesResource
    {
        Task<ApiResponse<Service>> GetById(int id);

        Task<ApiResponse<List<Service>>> Get(OData odata = null);

        Task<ApiResponse<Service>> Post(Service service, bool returnAllProperties = false);

        Task<HttpResponseMessage> Patch(int id, Service service);

        Task<HttpResponseMessage> Delete(int id);
    }
}