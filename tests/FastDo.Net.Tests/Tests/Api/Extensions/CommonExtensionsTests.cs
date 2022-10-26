using FastDo.Net.Api.Extensions;
using FastDo.Net.Tests.Models;

namespace FastDo.Net.Tests.Tests.Api.Extensions
{
    public class CommonExtensionsTests
    {
        [Theory]
        [InlineData("Test", "Test", false)]
        [InlineData("Test", "      ", false)]
        [InlineData("     ", "Test", false)]
        [InlineData("Test", "", true)]
        [InlineData("", "Test", true)]
        [InlineData(null, "Test", true)]
        [InlineData("Test", null, true)]
        public void IsAnyStringNullOrEmpty_Test(string name, string description, bool expectedResult)
        {
            var testClass = new TestClass() { Name = name, Description = description };

            var result = testClass.IsAnyStringNullOrEmpty();

            Assert.Equal(expectedResult, result);
        }
    }
}
