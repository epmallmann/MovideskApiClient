using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TicketAsset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("categoryFull")]
        public List<string> CategoryFull { get; set; }

        [JsonProperty("categoryFirstLevel")]
        public string CategoryFirstLevel { get; set; }

        [JsonProperty("categorySecondLevel")]
        public string CategorySecondLevel { get; set; }

        [JsonProperty("categoryThirdLevel")]
        public string CategoryThirdLevel { get; set; }

        [JsonProperty("isDeleted")]
        public bool? IsDeleted { get; set; }
    }
}
