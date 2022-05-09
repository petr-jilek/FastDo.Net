using Microsoft.Extensions.DependencyInjection;

namespace ApiCommon.Domain.Extensions
{
    public static class ServiceInjectionExtension
    {
        private static IServiceCollection AddService(this IServiceCollection services, Type type, ServiceLifetime lifetime)
            => lifetime switch
            {
                ServiceLifetime.Singleton => services.AddSingleton(type),
                ServiceLifetime.Scoped => services.AddScoped(type),
                ServiceLifetime.Transient => services.AddTransient(type),
                _ => services.AddScoped(type)
            };

        public static IServiceCollection AddByInterface<T>(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {
            var types = typeof(T).Assembly
                .GetTypes()
                .Where(myType => myType.IsClass
                        && myType.IsAbstract == false
                        && myType.GetInterfaces()
                            .Any(@interface => @interface == typeof(T)));

            foreach (var type in types)
                services.AddService(type, lifetime);

            return services;
        }
    }
}
