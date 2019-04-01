using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;

namespace Movidesk.Api.Client.Clients
{
    public class TicketClient : MovideskApiClient
    {
        public TicketClient(MovideskApiClientOptions options) : base(options, "/tickets")
        {
        }

        public async Task<ApiResponse<Ticket>> Get(int id, bool includeDeletedItems = false)
        {
            var result = await base.Get<Ticket>($"&id={id}&includeDeletedItems={includeDeletedItems}");
            return result;
        }

        public async Task<ApiResponse<List<Ticket>>> Get(OData odata, bool includeDeletedItems = false)
        {
            var result = await base.Get<List<Ticket>>($"&includeDeletedItems={includeDeletedItems}{odata?.ToString()}");
            return result;
        }

        public async Task<ApiResponse<Ticket>> Post(Person person, bool returnAllProperties = false)
        {
            var result = await Post<Ticket>($"&returnAllProperties={returnAllProperties}", person);
            return result;
        }

        public async Task<HttpResponseMessage> Patch(int id, object person)
        {
            var result = await Patch($"&id={id}", person);
            return result;
        }
    }
}
