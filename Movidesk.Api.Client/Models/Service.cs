using Movidesk.Api.Client.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Service
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("parentServiceId")]
        public int? ParentServiceId { get; set; }

        [JsonProperty("serviceForTicketType")]
        public ServiceTicketType? ServiceForTicketType { get; set; }

        [JsonProperty("isVisible")]
        public ServiceVisibility? IsVisible { get; set; }

        [JsonProperty("allowSelection")]
        public ServiceSelection? AllowSelection { get; set; }

        [JsonProperty("allowFinishTicket")]
        public bool? AllowFinishTicket { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("automationMacro")]
        public string AutomationMacro { get; set; }

        [JsonProperty("defaultCategory")]
        public string DefaultCategory { get; set; }

        [JsonProperty("defaultUrgency")]
        public string DefaultUrgency { get; set; }

        [JsonProperty("allowAllCategories")]
        public bool? AllowAllCategories { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }
    }
}
