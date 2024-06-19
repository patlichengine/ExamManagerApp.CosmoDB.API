using ExamManagerApp.CosmoDB.API.Models;
using Newtonsoft.Json;

namespace ExamManagerApp.CosmoDB.API.DTOs
{
    public class QuestionCreateDto
    {
        [JsonProperty(PropertyName = "questionType")]
        public List<QuestionType> QuestionType { get; set; }
    }

}
