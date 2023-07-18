namespace FastDo.Net.Domain.Models
{
    public class OAuthClientCredentialsSecure
    {
        public string? ClientId { get; set; }
        public PasswordCredentials? ClientSecretCredentials { get; set; }
    }
}
