using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    public class TicketCustomFieldValue
    {
        [JsonProperty("customFieldId")]
        public int CustomFieldId { get; set; }

        [JsonProperty("customFieldRuleId")]
        public int CustomFieldRuleId { get; set; }

        [JsonProperty("line")]
        public int Line { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("items")]
        public List<TicketCustomFieldValueItem> Items { get; set; }
    }
}
