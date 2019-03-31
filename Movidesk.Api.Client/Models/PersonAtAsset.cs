using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    public class PersonAtAsset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
