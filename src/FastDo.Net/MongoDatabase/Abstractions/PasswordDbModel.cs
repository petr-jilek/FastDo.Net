using FastDo.Net.Domain.Enums;

namespace FastDo.Net.MongoDatabase.Abstractions
{
    public abstract class PasswordDbModel : BaseDbModelStringId
    {
        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public HashMethod PasswordHashMethod { get; set; }
    }
}
