using ApiCommon.Domain.Enums;

namespace ApiCommon.MongoDatabase.Abstractions
{
    public abstract class PasswordDbModel : BaseDbModelStringId
    {
        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public HashMethod PasswordHashMethod { get; set; }
    }
}
