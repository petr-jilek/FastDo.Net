using ApiCommon.MongoDatabase.Abstractions;

namespace ApiCommon.MongoDatabase.Models.Users
{
    public class AppUser : BaseDbModelStringId
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public int PasswordHashMethod { get; set; }
    }
}
