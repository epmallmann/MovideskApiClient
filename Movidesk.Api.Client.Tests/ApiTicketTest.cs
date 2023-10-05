using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Movidesk.Api.Client.Tests
{
    public class ApiTicketTest : BaseTest
    {
        private readonly MovideskApiClientOptions _options;

        public ApiTicketTest()
        {
            _options = new MovideskApiClientOptions { Token = Token };
        }

        [Fact]
        public async void GetAllNoSelectTest()
        {
            var client = GetClient();
            var result = await client.Tickets.Get(new OData { Select = "" });

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
        }

        [Fact]
        public async void GetAllIdTest()
        {
            var client = GetClient();
            var result = await client.Tickets.Get(new OData { Select = "id" });

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.True(result.ResponseObject.Count > 0);
            Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.Subject));
        }

        [Fact]
        public async void GetByIdTest()
        {
            var client = GetClient();
            var result = await client.Tickets.GetById(81);

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.Equal(81, result.ResponseObject.Id.Value);
        }

        [Fact]
        public async void PostFailTest()
        {
            var client = GetClient();
            var result = await client.Tickets.Post(new Ticket { });

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
        }

        [Fact]
        public async Task SimplePostTest()
        {
            var client = GetClient();
            var result = await client.Tickets.Post(GetFakeTicket());

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.True(result.ResponseObject.Id.HasValue);
        }

        [Fact]
        public async void SimplePatchTest()
        {
            var client = GetClient();
            var result = await client.Tickets.Post(GetFakeTicket());

            Console.WriteLine(result.InnerResponse.ToString());

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.True(result.ResponseObject.Id.HasValue);

            var ticket = result.ResponseObject;

            ticket.Subject = $"test_alter_{Guid.NewGuid()}";

            client = GetClient();
            var resultPatch = await client.Tickets.Patch(ticket.Id.Value, ticket);

            Assert.True(resultPatch.IsSuccessStatusCode);
        }

        private MovideskClient GetClient() => new MovideskClient(new MovideskApiClient(_options));

        private Ticket GetFakeTicket()
        {
            return new Ticket
            {
                Subject = $"test_{Guid.NewGuid()}",
                Type = Enums.TicketType.Internal,
                CreatedBy = new TicketPerson { Id = "1589544980" },
                Owner = new TicketPerson { Id = "1589544980" },
                OwnerTeam = "Administradores",
                Actions = new List<TicketAction>
                {
                    new TicketAction {
                        Description = $"test_{Guid.NewGuid()}",
                        Type = Enums.TicketType.Internal
                    }
                },
                Clients = new List<TicketClient>
                {
                    new TicketClient { Id = "1589544980" }
                }
            };
        }
    }
}
