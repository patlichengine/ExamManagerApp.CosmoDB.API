using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ExamManagerApp.CosmoDB.API.Models
{
    public class QuestionDocument
    {
        //(Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "paragraph")]
        public string Paragraph { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "yesNo")]
        public bool YesNo { get; set; } = false;

        [JsonProperty(PropertyName = "dropdown")]
        public bool Dropdown { get; set; } = false;

        [JsonProperty(PropertyName = "multipleChoice")]
        public bool MultipleChoice { get; set; } = false;
        
        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; } = DateTime.Now;
        
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "questionType")]
        public string QuestionType { get; set; }

    }

}
