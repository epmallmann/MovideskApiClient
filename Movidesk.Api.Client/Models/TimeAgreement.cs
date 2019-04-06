using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TimeAgreement
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("emailSubject")]
        public string EmailSubject { get; set; }

        [JsonProperty("emailDescription")]
        public string EmailDescription { get; set; }

        [JsonProperty("emailAccount")]
        public string EmailAccount { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty("differentiateHoursFranchise")]
        public bool? DifferentiateHoursFranchise { get; set; }

        [JsonProperty("differentiateHoursConsumption")]
        public bool? DifferentiateHoursConsumption { get; set; }

        [JsonProperty("accumulateUnusedHours")]
        public bool? AccumulateUnusedHours { get; set; }

        [JsonProperty("renewalDay")]
        public byte? RenewalDay { get; set; }

        [JsonProperty("contractedHours")]
        public int? ContractedHours { get; set; }

        [JsonProperty("consumptionDeadline")]
        public byte? ConsumptionDeadline { get; set; }

        [JsonProperty("emailSendDay")]
        public byte? EmailSendDay { get; set; }

        [JsonProperty("baseAmount")]
        public decimal? BaseAmount { get; set; }

        [JsonProperty("createdOn")]
        public DateTime? CreatedOn { get; set; }

        [JsonProperty("disabledDate")]
        public DateTime? DisabledDate { get; set; }

        [JsonProperty("typeActivities")]
        public List<TimeAgreementTypeActivity> TypeActivities { get; set; }

        [JsonProperty("timeTypeConsumption")]
        public List<TimeAgreementTimeTypeConsumption> TimeTypeConsumption { get; set; }

        [JsonProperty("emailDestinations")]
        public List<TimeAgreementEmailDestination> EmailDestinations { get; set; }

        [JsonProperty("clients")]
        public List<TimeAgreementClient> Clients { get; set; }
    }
}
