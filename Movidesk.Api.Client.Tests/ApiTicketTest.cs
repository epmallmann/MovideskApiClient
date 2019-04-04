using Movidesk.Api.Client.Clients;
using Movidesk.Api.Client.Models;
using Movidesk.Api.Client.Utils;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void GetAllNoSelectTest()
        {
            var client = GetClient();
            var result = client.Tickets.Get(new OData { Select = "" }).Result;

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
        }

        [Fact]
        public void GetAllIdTest()
        {
            var client = GetClient();
            var result = client.Tickets.Get(new OData { Select = "id" }).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.True(result.ResponseObject.Count > 0);
            Assert.DoesNotContain(result.ResponseObject, x => !string.IsNullOrEmpty(x.Subject));
        }

        [Fact]
        public void GetByIdTest()
        {
            var client = GetClient();
            var result = client.Tickets.GetById(3).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.Equal(3, result.ResponseObject.Id.Value);
        }

        [Fact]
        public void PostFailTest()
        {
            var client = GetClient();
            var result = client.Tickets.Post(new Ticket { }).Result;

            Assert.False(result.InnerResponse.IsSuccessStatusCode);
        }

        [Fact]
        public Ticket SimplePostTest()
        {
            var client = GetClient();
            var result = client.Tickets.Post(GetFakeTicket()).Result;

            Assert.True(result.InnerResponse.IsSuccessStatusCode);
            Assert.NotNull(result.ResponseObject);
            Assert.True(result.ResponseObject.Id.HasValue);

            return result.ResponseObject;
        }

        [Fact]
        public void SimplePatchTest()
        {
            var ticket = SimplePostTest();

            ticket.Subject = $"test_alter_{Guid.NewGuid().ToString()}";

            var client = GetClient();
            var result = client.Tickets.Patch(ticket.Id.Value, ticket).Result;

            Assert.True(result.IsSuccessStatusCode);
        }

        private MovideskClient GetClient() => new MovideskClient(new MovideskApiClient(_options));

        private Ticket GetFakeTicket()
        {
            return new Ticket
            {
                Subject = $"test_{Guid.NewGuid().ToString()}",
                Type = Enums.TicketType.Internal,
                CreatedBy = new TicketPerson { Id = "539639646" },
                Owner = new TicketPerson { Id = "539639646" },
                OwnerTeam = "Administradores",
                Actions = new List<TicketAction>
                {
                    new TicketAction {
                        Description = $"test_{Guid.NewGuid().ToString()}",
                        Type = Enums.TicketType.Internal
                    }
                },
                Clients = new List<TicketClient>
                {
                    new TicketClient { Id = "539639646" }
                }
            };
        }
    }
}
