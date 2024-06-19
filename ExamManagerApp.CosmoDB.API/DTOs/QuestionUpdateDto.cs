using Newtonsoft.Json;

namespace ExamManagerApp.CosmoDB.API.DTOs
{
    public class QuestionUpdateDto : QuestionCreateDto
    {

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}
