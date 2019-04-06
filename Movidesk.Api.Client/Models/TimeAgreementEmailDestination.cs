using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TimeAgreementEmailDestination
    {
        [JsonProperty("type")]
        public object Type { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
