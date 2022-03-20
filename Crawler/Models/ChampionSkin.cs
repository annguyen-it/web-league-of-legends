using System.Text.Json.Serialization;

namespace Crawler.Models
{
    public class ChampionSkin
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("num")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("chromas")]
        public bool IsChroma { get; set; }
    }
}
