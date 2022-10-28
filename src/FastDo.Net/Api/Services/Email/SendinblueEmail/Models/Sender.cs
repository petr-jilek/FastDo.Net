using System.Text.Json.Serialization;

namespace FastDo.Net.Api.Services.Email.SendinblueEmail.Models
{
    public class Sender
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
