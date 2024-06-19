using Newtonsoft.Json;

namespace ExamManagerApp.CosmoDB.API.DTOs
{
    public class QuestionCreateDto
    {

        [JsonProperty("paragraph")]
        public string Paragraph { get; set; } = string.Empty;

        [JsonProperty("yesNo")]
        public bool YesNo { get; set; } = false;

        [JsonProperty("dropdown")]
        public bool Dropdown { get; set; } = false;
        [JsonProperty("multipleChoice")]
        public bool MultipleChoice { get; set; } = false;

        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("number")]
        public int Number { get; set; } = 2;

    }

}
