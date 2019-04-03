using Movidesk.Api.Client.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movidesk.Api.Client.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class TicketSatisfactionSurveyResponse
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("responsedBy")]
        public TicketPerson ResponsedBy { get; set; }

        [JsonProperty("responseDate")]
        public DateTime? ResponseDate { get; set; }

        [JsonProperty("satisfactionSurveyModel")]
        public SatisfactionSurveyModel? SatisfactionSurveyModel { get; set; }

        [JsonProperty("satisfactionSurveyNetPromoterScoreResponse")]
        public int? SatisfactionSurveyNetPromoterScoreResponse { get; set; }

        [JsonProperty("satisfactionSurveyPositiveNegativeResponse")]
        public SatisfactionSurveyPositiveNegativeResponse? SatisfactionSurveyPositiveNegativeResponse { get; set; }

        [JsonProperty("satisfactionSurveySmileyFacesResponse")]
        public SatisfactionSurveyPositiveNegativeResponse? SatisfactionSurveySmileyFacesResponse { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }
    }
}
