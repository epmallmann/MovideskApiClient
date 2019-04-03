using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TicketActionTimeAppointment
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("periodStart")]
        public TimeSpan? PeriodStart { get; set; }

        [JsonProperty("periodEnd")]
        public TimeSpan? PeriodEnd { get; set; }

        [JsonProperty("workTime")]
        public TimeSpan? WorkTime { get; set; }

        [JsonProperty("workTypeName")]
        public string WorkTypeName { get; set; }

        [JsonProperty("createdBy")]
        public TicketPerson CreatedBy { get; set; }

        [JsonProperty("createdByTeam")]
        public TicketActionTimeAppointmentCreatedByTeam CreatedByTeam { get; set; }
    }
}
