using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TimeAgreementTypeActivity
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("workingTimeType")]
        public string WorkingTimeType { get; set; }

        [JsonProperty("activity")]
        public string Activity { get; set; }

        [JsonProperty("franchise")]
        public int? Franchise { get; set; }

        [JsonProperty("value")]
        public decimal? Value { get; set; }

        [JsonProperty("valueExceededHour")]
        public decimal? ValueExceededHour { get; set; }
        
        [JsonProperty("shootdownContract")]
        public bool? ShootdownContract { get; set; }

        [JsonProperty("allowHoursExcedent")]
        public bool? AllowHoursExcedent { get; set; }
    }
}
