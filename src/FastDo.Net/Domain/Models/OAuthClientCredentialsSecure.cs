namespace FastDo.Net.Domain.Models
{
    public class OAuthClientCredentialsSecure
    {
        public string? ClientId { get; set; }
        public string? ClientSecretHash { get; set; }
        public string? Salt { get; set; }
        public int HashMethod { get; set; }
    }
}
