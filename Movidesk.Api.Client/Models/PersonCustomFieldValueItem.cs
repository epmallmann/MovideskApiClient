using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PersonCustomFieldValueItem
    {
        [JsonProperty("personId")]
        public int? PersonId { get; set; }

        [JsonProperty("clientId")]
        public int? ClientId { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("customFieldItem")]
        public string CustomFieldItem { get; set; }
    }
}
