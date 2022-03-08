using System.Text.Json.Serialization;

namespace Crawler.Models
{
    public class ChampionStats
    {

        [JsonPropertyName("idChampion")]
        public string IdChampion { get; set; }

        [JsonPropertyName("hp")]
        public float Hp { get; set; }

        [JsonPropertyName("hpPerLevel")]
        public float HpPerLevel { get; set; }

        [JsonPropertyName("mp")]
        public float Mp { get; set; }

        [JsonPropertyName("mpPerLevel")]
        public float MpPerLevel { get; set; }

        [JsonPropertyName("moveSpeed")]
        public float MoveSpeed { get; set; }

        [JsonPropertyName("armor")]
        public float Armor { get; set; }

        [JsonPropertyName("armorPerLevel")]
        public float ArmorPerLevel { get; set; }

        [JsonPropertyName("spellBlock")]
        public float SpellBlock { get; set; }

        [JsonPropertyName("spellBlockPerLevel")]
        public float SpellBlockPerLevel { get; set; }

        [JsonPropertyName("attackRange")]
        public float AttackRange { get; set; }

        [JsonPropertyName("hpRegen")]
        public float HpRegen { get; set; }

        [JsonPropertyName("hpRegenPerLevel")]
        public float HpRegenPerLevel { get; set; }

        [JsonPropertyName("mpRegen")]
        public float MpRegen { get; set; }

        [JsonPropertyName("mpRegenPerLevel")]
        public float MpRegenPerLevel { get; set; }

        [JsonPropertyName("crit")]
        public float Crit { get; set; }

        [JsonPropertyName("critPerLevel")]
        public float CritPerLevel { get; set; }

        [JsonPropertyName("attackDamage")]
        public float AttackDamage { get; set; }

        [JsonPropertyName("attackDamagePerLevel")]
        public float AttackDamagePerLevel { get; set; }

        [JsonPropertyName("attackSpeed")]
        public float AttackSpeed { get; set; }

        [JsonPropertyName("attackSpeedPerLevel")]
        public float AttackSpeedPerLevel { get; set; }
    }
}
