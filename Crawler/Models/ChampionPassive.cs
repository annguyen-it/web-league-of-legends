using System.Text.Json.Serialization;

namespace Crawler.Models
{
    public class ChampionPassive
    {

        [JsonPropertyName("idChampion")]
        public string IdChampion { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
