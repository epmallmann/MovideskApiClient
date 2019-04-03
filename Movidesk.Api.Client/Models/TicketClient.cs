using Movidesk.Api.Client.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TicketClient
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("businessName")]
        public string BusinessName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("personType")]
        public PersonType? PersonType { get; set; }

        [JsonProperty("profileType")]
        public ProfileType? ProfileType { get; set; }

        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty("organization")]
        public TicketPerson Organization { get; set; }
    }
}
