using System.Text.Json.Serialization;

namespace FastDo.Net.Api.Services.Email.SendinblueEmail.Models
{
    public class EmailUser
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}
