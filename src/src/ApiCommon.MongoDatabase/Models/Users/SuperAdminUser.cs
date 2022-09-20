using ApiCommon.MongoDatabase.Abstractions;

namespace ApiCommon.MongoDatabase.Models.Users
{
    public class SuperAdminUser : BaseDbModelStringId
    {
        public string? Email { get; set; }

        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public int PasswordHashMethod { get; set; }
    }
}
