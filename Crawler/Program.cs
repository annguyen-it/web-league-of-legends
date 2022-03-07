using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Crawler.Model;
using System.Text.RegularExpressions;

namespace Crawler
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string ConnectionString = "Server=14.225.255.234;Database=LeagueOfLegends;UID=SA;PWD=sqlServer00password;Integrated Security=false;";

        static void Main(string[] args)
        {
            var response = ProcessChampions();
            if (response == null)
                return;

            var champions = response["data"].ToObject<Dictionary<string, Champion>>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                // Insert champions
                foreach (var champion in champions.Values)
                {
                    Console.WriteLine(champion.Name);
                    var query = $"INSERT INTO Champion(id, [key], name, title, blurb, lore, parType, image) VALUES " +
                        $"('{champion.Id}', '{champion.Key}', '{champion.Name.Replace("'", "''")}', '{champion.Title.Replace("'", "''")}', '{champion.Blurb.Replace("'", "''")}', '', '{champion.ParType}', '{champion.Image.Full}')";
                    Console.WriteLine(query);
                    new SqlCommand(query, connection).ExecuteNonQuery();
                }

                // Insert tags
                List<string> tags = new List<string>();
                foreach (var champion in champions.Values)
                {
                    List<string> championTags = champion
                }
                connection.Close();
            }
        }

        private static JObject ProcessChampions()
        {
            var data = client.GetStringAsync("https://ddragon.leagueoflegends.com/cdn/12.5.1/data/en_US/champion.json").Result;
            var obj = JObject.Parse(data);
            return obj;
        }
    }
}