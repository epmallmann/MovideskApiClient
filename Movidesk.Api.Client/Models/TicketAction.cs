using Movidesk.Api.Client.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    public class TicketAction
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("type")]
        public TicketType? Type { get; set; }

        [JsonProperty("origin")]
        public TicketActionOrigin? Origin { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("htmlDescription")]
        public string HtmlDescription { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("justification")]
        public string Justification { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("createdBy")]
        public TicketPerson CreatedBy { get; set; }

        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty("timeAppointments")]
        public List<TicketActionTimeAppointment> TimeAppointments { get; set; }

        [JsonProperty("expenses")]
        public List<TicketActionExpense> Expenses { get; set; }

        [JsonProperty("attachments")]
        public List<TicketActionAttachment> Attachments { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
