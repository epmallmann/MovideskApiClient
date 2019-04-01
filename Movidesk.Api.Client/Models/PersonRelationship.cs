using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    public class PersonRelationship
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slaAgreement")]
        public string SlaAgreement { get; set; }

        [JsonProperty("forceChildrenToHaveSomeAgreement")]
        public bool? ForceChildrenToHaveSomeAgreement { get; set; }

        [JsonProperty("allowAllServices")]
        public bool? AllowAllServices { get; set; }

        [JsonProperty("includeInParents")]
        public bool? IncludeInParents { get; set; }

        [JsonProperty("loadChildOrganizations")]
        public bool? LoadChildOrganizations { get; set; }

        [JsonProperty("services")]
        public List<PersonRelationshipService> Services { get; set; }
    }
}
