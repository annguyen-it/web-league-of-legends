using System.Text.Json.Serialization;

namespace Crawler.Models
{
    public class Image
    {
        [JsonPropertyName("full")]
        public string Full { get; set; }
    }
}
