using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TimeAgreementTimeTypeConsumption
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("workingTimeType")]
        public string WorkingTimeType { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }
    }
}
