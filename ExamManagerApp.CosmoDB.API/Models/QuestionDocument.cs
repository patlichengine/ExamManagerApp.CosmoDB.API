using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ExamManagerApp.CosmoDB.API.Models
{
    public class QuestionDocument
    {
        //(Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty("questionId")]
        public string QuestionId { get; set; }

        [JsonProperty(PropertyName = "questionType")]
        public List<QuestionType>? QuestionType { get; set; } 
    }

    public class QuestionType
    {
        [JsonProperty(PropertyName = "id")] 
        public string Id { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "questionTemplate")]
        public QuestionTemplate template { get; set; }
    }

    public class QuestionTemplate
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }
        
        [JsonProperty(PropertyName = "otherOptions")]
        public bool? OtherOptions { get; set; } = false;

        [JsonProperty(PropertyName = "maxChoiceAllowed")]
        public int? MaxChoiceAllowed { get; set; }

        [JsonProperty(PropertyName = "choice")]
        public List<ChoiceTemplate>? Choice { get; set; } 
    }


    public class ChoiceTemplate
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "choice")]
        public string Choice { get; set; }
    }

}
