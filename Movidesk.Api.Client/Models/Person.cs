﻿using Movidesk.Api.Client.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("codeReferenceAdditional")]
        public string CodeReferenceAdditional { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("personType")]
        public PersonType PersonType { get; set; }

        [JsonProperty("profileType")]
        public ProfileType ProfileType { get; set; }

        [JsonProperty("accessProfile")]
        public string AccessProfile { get; set; }

        [JsonProperty("corporateName")]
        public string CorporateName { get; set; }

        [JsonProperty("businessName")]
        public string BusinessName { get; set; }

        [JsonProperty("cpfCnpj")]
        public string CpfCnpj { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("bossId")]
        public string BossId { get; set; }

        [JsonProperty("bossName")]
        public string BossName { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("cultureId")]
        public string CultureId { get; set; }

        [JsonProperty("timeZoneId")]
        public string TimeZoneId { get; set; }

        [JsonProperty("authenticateOn")]
        public string AuthenticateOn { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("changedDate")]
        public DateTime ChangedDate { get; set; }

        [JsonProperty("changedBy")]
        public string ChangedBy { get; set; }

        [JsonProperty("observations")]
        public string Observations { get; set; }

        [JsonProperty("addresses")]
        public List<PersonAddress> Addresses { get; set; } = new List<PersonAddress>();

        [JsonProperty("contacts")]
        public List<PersonContact> Contacts { get; set; } = new List<PersonContact>();

        [JsonProperty("emails")]
        public List<PersonEmail> Emails { get; set; } = new List<PersonEmail>();

        [JsonProperty("teams")]
        public List<string> Teams { get; set; } = new List<string>();

        [JsonProperty("relationships")]
        public List<PersonRelationship> Relationships { get; set; } = new List<PersonRelationship>();

        [JsonProperty("customFieldValues")]
        public List<PersonCustomFieldValue> CustomFieldValues { get; set; } = new List<PersonCustomFieldValue>();

        [JsonProperty("atAssets")]
        public List<PersonAtAsset> AtAssets { get; set; } = new List<PersonAtAsset>();
    }
}