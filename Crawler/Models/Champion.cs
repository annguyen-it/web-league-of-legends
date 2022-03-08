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

        [JsonPropertyName("info")]
        public ChampionInfo Info { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("stats")]
        public ChampionStats Stats { get; set; }

        [JsonPropertyName("passive")]
        public ChampionPassive? Passive { get; set; }

        [JsonPropertyName("spells")]
        public List<ChampionSpell>? Spells { get; set; }

        [JsonPropertyName("allyTips")]
        public List<string>? AllyTips { get; set; }

        [JsonPropertyName("enemyTips")]
        public List<string>? EnemyTips { get; set; }
    }
}
