namespace FastDo.Net.Api.Helpers
{
    public static class CommonHelper
    {
        public static bool IsInEnum<T>(int value) where T : struct, IConvertible
        {
            if (typeof(T).IsEnum == false)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.IsDefined(typeof(T), value);
        }
    }
}
