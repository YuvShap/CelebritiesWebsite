using Newtonsoft.Json;

namespace CelebritiesWebsite.Repository
{
    public class Celebrity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

    }
}