using System.Text.Json;

namespace FastDo.Net.Api.Extensions
{
    public static class JsonExtensions
    {
        public static T? ToJson<T>(this string data)
            => JsonSerializer.Deserialize<T>(data) ?? default;

        public static Dictionary<string, object> ToCommonJson(this string data)
            => JsonSerializer.Deserialize<Dictionary<string, object>>(data) ?? new Dictionary<string, object>();
    }
}
