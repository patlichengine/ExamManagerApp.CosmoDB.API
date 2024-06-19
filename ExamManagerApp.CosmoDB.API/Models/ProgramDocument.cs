using Newtonsoft.Json;

namespace ExamManagerApp.CosmoDB.API.Models
{
    public class ProgramDocument
    {
        //(Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "programId")]
        public string ProgramId { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = string.Empty;
    }
}
