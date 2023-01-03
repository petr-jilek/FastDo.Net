namespace FastDo.Net.Api.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsInt(this string input)
            => int.TryParse(input, out _);

        public static bool IsDouble(this string input)
            => double.TryParse(input, out _);

        public static bool IsFloat(this string input)
            => float.TryParse(input, out _);

        public static bool IsDecimal(this string input)
            => decimal.TryParse(input, out _);

        public static bool IsBool(this string input)
            => bool.TryParse(input, out _);
    }
}
