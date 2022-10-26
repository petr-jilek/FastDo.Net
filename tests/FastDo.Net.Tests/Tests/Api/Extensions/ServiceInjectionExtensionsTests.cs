using FastDo.Net.Api.Extensions;
using FastDo.Net.Tests.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastDo.Net.Tests.Tests.Api.Extensions
{
    public class ServiceInjectionExtensionsTests
    {
        [Fact]
        public void Ok()
        {
            var name = "Test";
            var description = "Test";

            var inMemorySettings = new Dictionary<string, string> {
                {"TestClass:Name", name},
                {"TestClass:Description", description},
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSettings<TestClass>(configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var testClass = scope.ServiceProvider.GetService<TestClass>();

            Assert.Equal(name, testClass.Name);
            Assert.Equal(description, testClass.Description);
        }
    }
}
