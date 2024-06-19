using Newtonsoft.Json;

namespace ExamManagerApp.CosmoDB.API.Models
{
    public class UserDocument
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
