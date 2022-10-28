using System.Text.Json.Serialization;

namespace FastDo.Net.Api.Services.Email.SendinblueEmail.Models
{
    public class Reciever
    {
        [JsonPropertyName("toName")]
        public string? ToName { get; set; }

        [JsonPropertyName("toEmail")]
        public string? ToEmail { get; set; }
    }
}
