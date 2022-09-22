using ApiCommon.MongoDatabase.Abstractions;

namespace ApiCommon.MongoDatabase.Models.Settings
{
    public class AppSettings : BaseDbModelStringId
    {
        public string? Key { get; set; }
        public object? Value { get; set; }
    }
}
