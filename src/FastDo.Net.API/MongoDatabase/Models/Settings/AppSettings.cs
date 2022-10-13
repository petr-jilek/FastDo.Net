using FastDo.Net.MongoDatabase.Abstractions;

namespace FastDo.Net.MongoDatabase.Models.Settings
{
    public class AppSettings : BaseDbModelStringId
    {
        public string? Key { get; set; }
        public object? Value { get; set; }
    }
}
