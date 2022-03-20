using System.Text.Json.Serialization;

namespace Crawler.Models
{
    public class ChampionInfo
    {
        [JsonPropertyName("idChampion")]
        public string IdChampion { get; set; }

        [JsonPropertyName("attack")]
        public int Attack { get; set; }

        [JsonPropertyName("defense")]
        public int Defense { get; set; }

        [JsonPropertyName("magic")]
        public int Magic { get; set; }

        [JsonPropertyName("difficulty")]
        public int Difficulty { get; set; }
    }
}
