using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movidesk.Api.Client.Resources
{
    public interface ITicketResource
    {
        Task<ApiResponse<Ticket>> Get(int id, bool includeDeletedItems = false);

        Task<ApiResponse<List<Ticket>>> Get(OData odata, bool includeDeletedItems = false);

        Task<ApiResponse<Ticket>> Post(Ticket ticket, bool returnAllProperties = false);

        Task<HttpResponseMessage> Patch(int id, object ticket);
    }
}