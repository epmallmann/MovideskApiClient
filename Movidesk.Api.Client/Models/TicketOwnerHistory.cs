using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TicketOwnerHistory
    {
        [JsonProperty("ownerTeam")]
        public string OwnerTeam { get; set; }

        [JsonProperty("owner")]
        public TicketPerson Owner { get; set; }

        [JsonProperty("permanencyTimeFullTime")]
        public double? PermanencyTimeFullTime { get; set; }

        [JsonProperty("permanencyTimeWorkingTime")]
        public double? PermanencyTimeWorkingTime { get; set; }

        [JsonProperty("changedBy")]
        public TicketPerson ChangedBy { get; set; }

        [JsonProperty("changedDate")]
        public DateTime? ChangedDate { get; set; }
    }
}
