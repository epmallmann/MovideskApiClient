using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    public class TicketStatusHistory
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("justification")]
        public string Justification { get; set; }

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
