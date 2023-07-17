using FastDo.Net.Domain.Models;

namespace FastDo.Net.MongoDatabase.Abstractions
{
    public abstract class PasswordDbModel : BaseDbModelStringId
    {
        public PasswordCredentials? PasswordCredentials { get; set; }
    }
}
