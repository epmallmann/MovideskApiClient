using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PersonContact
    {
        [JsonProperty("contactType")]
        public string ContactType { get; set; }

        [JsonProperty("contact")]
        public string Contact { get; set; }

        [JsonProperty("isDefault")]
        public bool? IsDefault { get; set; }
    }
}
