using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class PersonEmail
    {
        [JsonProperty("emailType")]
        public string EmailType { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("isDefault")]
        public bool? IsDefault { get; set; }
    }
}
