using FastDo.Net.Domain.Consts;

namespace FastDo.Net.Api.Helpers
{
    public static class EnviromentHelper
    {
        public static bool IsDevelopment()
            => Environment.GetEnvironmentVariable(GlobalConsts.EnviromentKey) == Enviroments.Development;

        public static bool IsTesting()
            => Environment.GetEnvironmentVariable(GlobalConsts.EnviromentKey) == Enviroments.Testing;

        public static bool IsStaging()
            => Environment.GetEnvironmentVariable(GlobalConsts.EnviromentKey) == Enviroments.Staging;

        public static bool IsDemo()
            => Environment.GetEnvironmentVariable(GlobalConsts.EnviromentKey) == Enviroments.Demo;

        public static bool IsProduction()
            => Environment.GetEnvironmentVariable(GlobalConsts.EnviromentKey) == Enviroments.Production;

        public static string? GetEnviroment()
            => Environment.GetEnvironmentVariable(GlobalConsts.EnviromentKey);
    }
}
