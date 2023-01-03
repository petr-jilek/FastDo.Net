using System.Text.Json.Serialization;

namespace FastDo.Net.Api.Models
{
    public class IdJsonClass
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}
