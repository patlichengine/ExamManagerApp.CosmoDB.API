using ExamManagerApp.CosmoDB.API.Models;
using Newtonsoft.Json;

namespace ExamManagerApp.CosmoDB.API.DTOs
{
    public class CandidateCreateDto
    {
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

        [JsonProperty(PropertyName = "dateofBirth")]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "question")]
        public List<QuestionType> Question { get; set; }

    }
}
