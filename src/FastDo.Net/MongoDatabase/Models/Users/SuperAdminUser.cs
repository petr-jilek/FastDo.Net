using FastDo.Net.Domain.Models;
using FastDo.Net.MongoDatabase.Abstractions;

namespace FastDo.Net.MongoDatabase.Models.Users
{
    public class SuperAdminUser : BaseDbModelStringId
    {
        public string? Email { get; set; }

        public PasswordCredentials? PasswordCredentials { get; set; }
    }
}
