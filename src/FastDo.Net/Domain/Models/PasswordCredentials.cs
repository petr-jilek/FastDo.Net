namespace FastDo.Net.Domain.Models
{
    public class PasswordCredentials
    {
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public int HashMethod { get; set; }
    }
}
