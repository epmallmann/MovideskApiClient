using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Http;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;

namespace Movidesk.Api.Client.Resources
{
    public class TicketResource : ITicketResource
    {
        private readonly IMovideskApiClient _apiClient;

        public TicketResource(IMovideskApiClient apiClient)
        {
            _apiClient = apiClient;
            _apiClient.Configure("/tickets");
        }

        public async Task<ApiResponse<Ticket>> Get(int id, bool includeDeletedItems = false)
        {
            var result = await _apiClient.Get<Ticket>($"&id={id}&includeDeletedItems={includeDeletedItems}");
            return result;
        }

        public async Task<ApiResponse<List<Ticket>>> Get(OData odata, bool includeDeletedItems = false)
        {
            var result = await _apiClient.Get<List<Ticket>>($"&includeDeletedItems={includeDeletedItems}{odata?.ToString()}");
            return result;
        }

        public async Task<HttpResponseMessage> Patch(int id, object ticket)
        {
            var result = await _apiClient.Patch($"&id={id}", ticket);
            return result;
        }

        public async Task<ApiResponse<Ticket>> Post(Ticket ticket, bool returnAllProperties = false)
        {
            var result = await _apiClient.Post<Ticket>($"&returnAllProperties={returnAllProperties}", ticket);
            return result;
        }
    }
}
