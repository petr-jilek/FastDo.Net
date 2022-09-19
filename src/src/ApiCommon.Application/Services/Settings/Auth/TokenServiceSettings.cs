namespace ApiCommon.Application.Services.Settings.Auth
{
    public class TokenServiceSettings
    {
        public string? Secret { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
