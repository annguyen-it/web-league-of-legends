using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Crawler.Model;

namespace Crawler
{
    class Program
    {
        private static readonly HttpClient client = new();
        private static readonly string ConnectionString = "Server=14.225.255.234;Database=LeagueOfLegends;UID=btl_web_login;PWD=sqlserver@Web-0;Integrated Security=false;";
        private static readonly string Version = "12.5.1";

        static void Main()
        {
            var response = ProcessChampions();
            if (response == null)
                return;

            var champions = response["data"].ToObject<Dictionary<string, Champion>>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            // Insert champions
            foreach (var champion in champions.Values)
            {
                Console.WriteLine(champion.Name);
                var query = "INSERT INTO Champion(id, [key], name, title, blurb, lore, parType, image) VALUES " +
                    $"('{champion.Id}', '{champion.Key}', '{champion.Name.Replace("'", "''")}', '{champion.Title.Replace("'", "''")}', '{champion.Blurb.Replace("'", "''")}', '', '{champion.ParType}', '{champion.Image.Full}')";
                Console.WriteLine(query);
                new SqlCommand(query, connection).ExecuteNonQuery();
            }

            // Insert tags
            var tags = new Dictionary<string, int>();
            foreach (var champion in champions.Values)
            {
                champion.Tags.ForEach(tag =>
                {
                    Console.WriteLine(champion.Name);
                    if (!tags.ContainsKey(tag))
                    {
                        tags.Add(tag, tags.Count + 1);
                        var tagQuery = $"INSERT INTO Tag(name) VALUES ('{tag}')";
                        Console.WriteLine(tagQuery);
                        new SqlCommand(tagQuery, connection).ExecuteNonQuery();
                    }
                    var query = $"INSERT INTO Champion_Tag(idChampion, idTag) VALUES ('{champion.Id}', '{tags.GetValueOrDefault(tag)}')";
                    Console.WriteLine(query);
                    new SqlCommand(query, connection).ExecuteNonQuery();
                });
            }

            //Insert champion info
            foreach (var champion in champions.Values)
            {
                Console.WriteLine(champion.Name);
                var query = $"INSERT INTO ChampionInfo(idChampion, attack, defense, magic, difficulty) VALUES ('{champion.Id}', '{champion.Info.Attack}', '{champion.Info.Defense}', '{champion.Info.Magic}', '{champion.Info.Difficulty}')";
                Console.WriteLine(query);
                new SqlCommand(query, connection).ExecuteNonQuery();
            }

            // Insert champion stats
            foreach (var champion in champions.Values)
            {
                Console.WriteLine(champion.Name);
                var query = "INSERT INTO ChampionStats(idChampion, hp, hpPerLevel, mp, mpPerLevel, moveSpeed, armor, armorPerLevel, spellBlock, spellBlockPerLevel, attackRange, hpRegen, hpRegenPerLevel, mpRegen, mpRegenPerLevel, crit, critPerLevel, attackDamage, attackDamagePerLevel, attackSpeed, attackSpeedPerLevel) " +
                    $"VALUES ('{champion.Id}', '{champion.Stats.Hp}', '{champion.Stats.HpPerLevel}', '{champion.Stats.Mp}', '{champion.Stats.MpPerLevel}', '{champion.Stats.MoveSpeed}', '{champion.Stats.Armor}', '{champion.Stats.ArmorPerLevel}', '{champion.Stats.SpellBlock}', '{champion.Stats.SpellBlockPerLevel}', '{champion.Stats.AttackRange}', '{champion.Stats.HpRegen}', '{champion.Stats.HpRegenPerLevel}', '{champion.Stats.MpRegen}', '{champion.Stats.MpRegenPerLevel}', '{champion.Stats.Crit}', '{champion.Stats.CritPerLevel}', '{champion.Stats.AttackDamage}', '{champion.Stats.AttackSpeedPerLevel}', '{champion.Stats.AttackSpeed}', '{champion.Stats.AttackSpeedPerLevel}')";
                Console.WriteLine(query);
                new SqlCommand(query, connection).ExecuteNonQuery();
            }

            // Insert champion passive
            foreach (var champion in champions.Values)
            {
                var detailsResponse = ProcessChampion(champion.Id)["data"].ToObject<Dictionary<string, Champion>>();
                foreach (var details in detailsResponse.Values)
                {
                    Console.WriteLine(champion.Name);
                    var query = "INSERT INTO Passive(idChampion, name, image, description) " +
                        $"VALUES ('{details.Id}', '{details.Passive?.Name.Replace("'", "''")}', '{details.Passive?.Image.Full}', '{details.Passive?.Description.Replace("'", "''")}')";
                    Console.WriteLine(query);
                    new SqlCommand(query, connection).ExecuteNonQuery();
                }
            }

            // Insert champion spells
            foreach (var champion in champions.Values)
            {
                var detailsResponse = ProcessChampion(champion.Id)["data"].ToObject<Dictionary<string, Champion>>();
                foreach (var details in detailsResponse.Values)
                {
                    Console.WriteLine(champion.Name);
                    if (details == null || details.Spells == null) continue;
                    foreach (var spell in details.Spells)
                    {
                        var query = "INSERT INTO Spell(id, idChampion, name, image, description, maxRank) " +
                            $"VALUES ('{spell.Id}', '{details.Id}', '{spell.Name.Replace("'", "''")}', '{spell.Image.Full}', '{spell.Description.Replace("'", "''")}', '{spell.MaxRank}')";
                        Console.WriteLine(query);
                        new SqlCommand(query, connection).ExecuteNonQuery();
                    }
                }
            }

            // Insert tips
            foreach (var champion in champions.Values)
            {
                var detailsResponse = ProcessChampion(champion.Id)["data"].ToObject<Dictionary<string, Champion>>();
                foreach (var details in detailsResponse.Values)
                {
                    Console.WriteLine(champion.Name);
                    if (details != null && details.AllyTips != null)
                    {
                        foreach (var tip in details.AllyTips)
                        {
                            var query = $"INSERT INTO Tip(idChampion, tip, forAlly) VALUES ('{details.Id}', '{tip.Replace("'", "''")}', 1)";
                            Console.WriteLine(query);
                            new SqlCommand(query, connection).ExecuteNonQuery();
                        }
                    }
                    if (details != null && details.EnemyTips != null)
                    {
                        foreach (var tip in details.EnemyTips)
                        {
                            var query = $"INSERT INTO Tip(idChampion, tip, forAlly) VALUES ('{details.Id}', '{tip.Replace("'", "''")}', 0)";
                            Console.WriteLine(query);
                            new SqlCommand(query, connection).ExecuteNonQuery();
                        }
                    }
                }
            }

            connection.Close();
        }

        private static JObject ProcessChampions()
        {
            var data = client.GetStringAsync($"https://ddragon.leagueoflegends.com/cdn/{Version}/data/en_US/champion.json").Result;
            var obj = JObject.Parse(data);
            return obj;
        }

        private static JObject ProcessChampion(string id)
        {
            var data = client.GetStringAsync($"https://ddragon.leagueoflegends.com/cdn/{Version}/data/en_US/champion/{id}.json").Result;
            var obj = JObject.Parse(data);
            return obj;
        }
    }
}