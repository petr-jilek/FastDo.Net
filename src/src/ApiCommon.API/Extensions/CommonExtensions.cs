namespace ApiCommon.API.Extensions
{
    public static class CommonExtensions
    {
        public static bool IsAnyStringNullOrEmpty(this object obj)
            => obj.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string?)pi.GetValue(obj))
                .Any(string.IsNullOrEmpty);
    }
}
