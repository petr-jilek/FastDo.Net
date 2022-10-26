using FastDo.Net.Api.Extensions;
using FastDo.Net.Tests.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastDo.Net.Tests.Tests.Api.Extensions
{
    public class ServiceInjectionExtensionsTests
    {
        [Fact]
        public void AddSettings_Ok()
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

            var testClass = serviceProvider.GetService<TestClass>();

            Assert.NotNull(testClass);
            Assert.Equal(name, testClass.Name);
            Assert.Equal(description, testClass.Description);
        }

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void AddByInterface_Scoped_Ok(ServiceLifetime serviceLifetime)
        {
            // Create class instances manualy
            var testClass1 = new TestClass1();
            var testClass2 = new TestClass2();

            // Create service collection
            var serviceCollection = new ServiceCollection();


            // Add classes to service collection by interface ITestClass
            serviceCollection.AddByInterface<ITestClass>(serviceLifetime);

            // Build service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Create 1. scope and get servicies
            using var scope1 = serviceProvider.CreateScope();
            var testClass1Service1Scope1 = scope1.ServiceProvider.GetService<TestClass1>();
            var testClass2Service1Scope1 = scope1.ServiceProvider.GetService<TestClass2>();
            var testClass1Service2Scope1 = scope1.ServiceProvider.GetService<TestClass1>();
            var testClass2Service2Scope1 = scope1.ServiceProvider.GetService<TestClass2>();

            // Create 2. scope and get servicies
            using var scope2 = serviceProvider.CreateScope();
            var testClass1Service1Scope2 = scope2.ServiceProvider.GetService<TestClass1>();
            var testClass2Service1Scope2 = scope2.ServiceProvider.GetService<TestClass2>();
            var testClass1Service2Scope2 = scope2.ServiceProvider.GetService<TestClass1>();
            var testClass2Service2Scope2 = scope2.ServiceProvider.GetService<TestClass2>();

            // Check if instances are not null
            Assert.NotNull(testClass1Service1Scope1);
            Assert.NotNull(testClass2Service1Scope1);
            Assert.NotNull(testClass1Service2Scope1);
            Assert.NotNull(testClass2Service2Scope1);
            Assert.NotNull(testClass1Service1Scope2);
            Assert.NotNull(testClass2Service1Scope2);
            Assert.NotNull(testClass1Service2Scope2);
            Assert.NotNull(testClass2Service2Scope2);

            // Check common behaviour of the services
            Assert.Equal(testClass1.GetStr(), testClass1Service1Scope1.GetStr());
            Assert.Equal(testClass2.GetStr(), testClass2Service1Scope1.GetStr());
            Assert.Equal(testClass1.GetStr(), testClass1Service2Scope1.GetStr());
            Assert.Equal(testClass2.GetStr(), testClass2Service2Scope1.GetStr());
            Assert.Equal(testClass1.GetStr(), testClass1Service1Scope2.GetStr());
            Assert.Equal(testClass2.GetStr(), testClass2Service1Scope2.GetStr());
            Assert.Equal(testClass1.GetStr(), testClass1Service2Scope2.GetStr());
            Assert.Equal(testClass2.GetStr(), testClass2Service2Scope2.GetStr());

            if (serviceLifetime == ServiceLifetime.Transient)
            {
                // In same scope services must be the same instance
                Assert.NotEqual(testClass1Service1Scope1.GetHashCode(), testClass1Service2Scope1.GetHashCode());
                Assert.NotEqual(testClass2Service1Scope1.GetHashCode(), testClass2Service2Scope1.GetHashCode());
                Assert.NotEqual(testClass1Service1Scope2.GetHashCode(), testClass1Service2Scope2.GetHashCode());
                Assert.NotEqual(testClass2Service1Scope2.GetHashCode(), testClass2Service2Scope2.GetHashCode());

                // In different scope services must not be the same instance
                Assert.NotEqual(testClass1Service1Scope1.GetHashCode(), testClass1Service1Scope2.GetHashCode());
                Assert.NotEqual(testClass2Service1Scope1.GetHashCode(), testClass2Service1Scope2.GetHashCode());
                Assert.NotEqual(testClass1Service2Scope1.GetHashCode(), testClass1Service2Scope2.GetHashCode());
                Assert.NotEqual(testClass2Service2Scope1.GetHashCode(), testClass2Service2Scope2.GetHashCode());
            }
            else if (serviceLifetime == ServiceLifetime.Scoped)
            {
                // In same scope services must be the same instance
                Assert.Equal(testClass1Service1Scope1.GetHashCode(), testClass1Service2Scope1.GetHashCode());
                Assert.Equal(testClass2Service1Scope1.GetHashCode(), testClass2Service2Scope1.GetHashCode());
                Assert.Equal(testClass1Service1Scope2.GetHashCode(), testClass1Service2Scope2.GetHashCode());
                Assert.Equal(testClass2Service1Scope2.GetHashCode(), testClass2Service2Scope2.GetHashCode());

                // In different scope services must not be the same instance
                Assert.NotEqual(testClass1Service1Scope1.GetHashCode(), testClass1Service1Scope2.GetHashCode());
                Assert.NotEqual(testClass2Service1Scope1.GetHashCode(), testClass2Service1Scope2.GetHashCode());
                Assert.NotEqual(testClass1Service2Scope1.GetHashCode(), testClass1Service2Scope2.GetHashCode());
                Assert.NotEqual(testClass2Service2Scope1.GetHashCode(), testClass2Service2Scope2.GetHashCode());
            }
            else if (serviceLifetime == ServiceLifetime.Singleton)
            {
                // In same scope services must be the same instance
                Assert.Equal(testClass1Service1Scope1.GetHashCode(), testClass1Service2Scope1.GetHashCode());
                Assert.Equal(testClass2Service1Scope1.GetHashCode(), testClass2Service2Scope1.GetHashCode());
                Assert.Equal(testClass1Service1Scope2.GetHashCode(), testClass1Service2Scope2.GetHashCode());
                Assert.Equal(testClass2Service1Scope2.GetHashCode(), testClass2Service2Scope2.GetHashCode());

                // In different scope services must not be the same instance
                Assert.Equal(testClass1Service1Scope1.GetHashCode(), testClass1Service1Scope2.GetHashCode());
                Assert.Equal(testClass2Service1Scope1.GetHashCode(), testClass2Service1Scope2.GetHashCode());
                Assert.Equal(testClass1Service2Scope1.GetHashCode(), testClass1Service2Scope2.GetHashCode());
                Assert.Equal(testClass2Service2Scope1.GetHashCode(), testClass2Service2Scope2.GetHashCode());
            }
        }
    }
}
