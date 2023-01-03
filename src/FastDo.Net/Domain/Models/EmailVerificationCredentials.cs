namespace FastDo.Net.Domain.Models
{
    public class EmailVerificationCredentials
    {
        public string? Token { get; set; }
        public bool Verified { get; set; }
    }
}
