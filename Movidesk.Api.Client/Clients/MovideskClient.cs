using Movidesk.Api.Client.Resources;
using System;
using System.Collections.Generic;
using System.Text;

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
        public IServicesResource Services => ServicesLazy.Value;

        private Lazy<IPersonResource> PersonsLazy => new Lazy<IPersonResource>(() => new PersonResource(_client));
        public IPersonResource Persons => PersonsLazy.Value;
    }
}
