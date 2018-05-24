using Newtonsoft.Json;

namespace WpfTutorial.Models
{
    public class ChuckNorrisFact
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
