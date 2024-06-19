using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ExamManagerApp.CosmoDB.API.Models
{
    public class CandidateDocument
    {
        //(Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "nationality")]
        public string Nationality { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "currentResidence")]
        public string CurrentResidence { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "idNumber")]
        public string IDNumber { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }
        [JsonProperty(PropertyName = "question")]
        public List<QuestionType>? Question { get; set; }

    }

}
