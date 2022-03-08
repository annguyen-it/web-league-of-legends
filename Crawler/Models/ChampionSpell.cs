using System.Text.Json.Serialization;

namespace Crawler.Models
{
    public class ChampionSpell
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("idChampion")]
        public string IdChampion { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("maxRank")]
        public int MaxRank { get; set; }
    }
}
