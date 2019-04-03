using Movidesk.Api.Client.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Ticket
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("type")]
        public TicketType? Type { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("urgency")]
        public string Urgency { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("baseStatus")]
        public string BaseStatus { get; set; }

        [JsonProperty("justification")]
        public string Justification { get; set; }

        [JsonProperty("origin")]
        public TicketOrigin? Origin { get; set; }

        [JsonProperty("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty("originEmailAccount")]
        public string OriginEmailAccount { get; set; }

        [JsonProperty("owner")]
        public TicketPerson Owner { get; set; }

        [JsonProperty("ownerTeam")]
        public string OwnerTeam { get; set; }

        [JsonProperty("createdBy")]
        public TicketPerson CreatedBy { get; set; }

        [JsonProperty("serviceFull")]
        public List<string> ServiceFull { get; set; }

        [JsonProperty("serviceFirstLevelId")]
        public int? ServiceFirstLevelId { get; set; }

        [JsonProperty("serviceFirstLevel")]
        public string ServiceFirstLevel { get; set; }

        [JsonProperty("serviceSecondLevel")]
        public string ServiceSecondLevel { get; set; }

        [JsonProperty("serviceThirdLevel")]
        public string ServiceThirdLevel { get; set; }

        [JsonProperty("contactForm")]
        public string ContactForm { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("cc")]
        public string Cc { get; set; }

        [JsonProperty("resolvedIn")]
        public DateTime? ResolvedIn { get; set; }

        [JsonProperty("reopenedIn")]
        public DateTime? ReopenedIn { get; set; }

        [JsonProperty("closedIn")]
        public DateTime? ClosedIn { get; set; }

        [JsonProperty("lastActionDate")]
        public DateTime? LastActionDate { get; set; }

        [JsonProperty("actionCount")]
        public int? ActionCount { get; set; }

        [JsonProperty("lastUpdate")]
        public DateTime? LastUpdate { get; set; }

        [JsonProperty("lifetimeWorkingTime")]
        public int? LifetimeWorkingTime { get; set; }

        [JsonProperty("stoppedTime")]
        public int? StoppedTime { get; set; }

        [JsonProperty("stoppedTimeWorkingTime")]
        public int? StoppedTimeWorkingTime { get; set; }

        [JsonProperty("resolvedInFirstCall")]
        public bool? ResolvedInFirstCall { get; set; }

        [JsonProperty("chatWidget")]
        public string ChatWidget { get; set; }

        [JsonProperty("chatGroup")]
        public string ChatGroup { get; set; }

        [JsonProperty("chatTalkTime")]
        public int? ChatTalkTime { get; set; }

        [JsonProperty("chatWaitingTime")]
        public int? ChatWaitingTime { get; set; }

        [JsonProperty("sequence")]
        public int? Sequence { get; set; }

        [JsonProperty("slaAgreement")]
        public string SlaAgreement { get; set; }

        [JsonProperty("slaAgreementRule")]
        public string SlaAgreementRule { get; set; }

        [JsonProperty("slaSolutionTime")]
        public int? SlaSolutionTime { get; set; }

        [JsonProperty("slaResponseTime")]
        public int? SlaResponseTime { get; set; }

        [JsonProperty("slaSolutionChangedByUser")]
        public bool? SlaSolutionChangedByUser { get; set; }

        [JsonProperty("slaSolutionChangedBy")]
        public TicketPerson SlaSolutionChangedBy { get; set; }

        [JsonProperty("slaSolutionDate")]
        public DateTime? SlaSolutionDate { get; set; }

        [JsonProperty("slaSolutionDateIsPaused")]
        public bool? SlaSolutionDateIsPaused { get; set; }

        [JsonProperty("slaResponseDate")]
        public DateTime? SlaResponseDate { get; set; }

        [JsonProperty("slaRealResponseDate")]
        public DateTime? SlaRealResponseDate { get; set; }

        [JsonProperty("jiraIssueKey")]
        public string JiraIssueKey { get; set; }

        [JsonProperty("redmineIssueId")]
        public int? RedmineIssueId { get; set; }

        [JsonProperty("clients")]
        public List<TicketClient> Clients { get; set; }

        [JsonProperty("actions")]
        public List<TicketAction> Actions { get; set; }

        [JsonProperty("parentTickets")]
        public List<TicketParentChild> ParentTickets { get; set; }

        [JsonProperty("childrenTickets")]
        public List<TicketParentChild> ChildrenTickets { get; set; }

        [JsonProperty("ownerHistories")]
        public List<TicketOwnerHistory> OwnerHistories { get; set; }

        [JsonProperty("statusHistories")]
        public List<TicketStatusHistory> StatusHistories { get; set; }

        [JsonProperty("satisfactionSurveyResponses")]
        public List<TicketSatisfactionSurveyResponse> SatisfactionSurveyResponses { get; set; }

        [JsonProperty("customFieldValues")]
        public List<TicketCustomFieldValue> CustomFieldValues { get; set; }

        [JsonProperty("assets")]
        public List<TicketAsset> Assets { get; set; }
    }
}
