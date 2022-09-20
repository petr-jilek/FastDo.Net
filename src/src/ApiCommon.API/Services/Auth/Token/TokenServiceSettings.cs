namespace ApiCommon.API.Services.Auth.Token
{
    public class TokenServiceSettings
    {
        public string? Secret { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
