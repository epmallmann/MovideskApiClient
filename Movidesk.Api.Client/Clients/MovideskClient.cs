using Movidesk.Api.Client.Resources;
using System;

namespace Movidesk.Api.Client.Clients
{
    public class MovideskClient
    {
        private readonly IMovideskApiClient _client;

        public MovideskClient(IMovideskApiClient client)
        {
            _client = client;
        }

        private Lazy<IServicesResource> ServicesLazy => new Lazy<IServicesResource>(() => new ServicesResource(_client));
        /// <summary>
        /// Interface of services
        /// </summary>
        public IServicesResource Services => ServicesLazy.Value;

        private Lazy<IPersonResource> PersonsLazy => new Lazy<IPersonResource>(() => new PersonResource(_client));
        /// <summary>
        /// Interface of persons
        /// </summary>
        public IPersonResource Persons => PersonsLazy.Value;

        private Lazy<ITicketResource> TicketsLazy => new Lazy<ITicketResource>(() => new TicketResource(_client));
        /// <summary>
        /// Interface of tickets
        /// </summary>
        public ITicketResource Tickets => TicketsLazy.Value;
    }
}
