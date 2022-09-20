namespace ApiCommon.Domain.Models
{
    public record BasicAuthCredentials
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
