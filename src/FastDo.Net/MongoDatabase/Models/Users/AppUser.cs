using FastDo.Net.Domain.Models;
using FastDo.Net.MongoDatabase.Abstractions;

namespace FastDo.Net.MongoDatabase.Models.Users
{
    public class AppUser : BaseDbModelStringId
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public PasswordCredentials? PasswordCredentials { get; set; }
    }
}
