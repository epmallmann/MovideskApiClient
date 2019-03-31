using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    public class PersonRelationshipService
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("copyToChildren")]
        public bool CopyToChildren { get; set; }
    }
}
