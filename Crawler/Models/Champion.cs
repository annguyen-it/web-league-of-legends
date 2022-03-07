using Crawler.Models;
using System.Text.Json.Serialization;

namespace Crawler.Model
{
    public class Champion
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("blurb")]
        public string Blurb { get; set; }

        [JsonPropertyName("partype")]
        public string ParType { get; set; }

        [JsonPropertyName("lore")]
        public string Lore { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }
    }
}
