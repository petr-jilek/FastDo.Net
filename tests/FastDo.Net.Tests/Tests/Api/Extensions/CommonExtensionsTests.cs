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

        [Theory]
        [InlineData("Ahoj jak se máš", "ahoj-jak-se-mas")]
        [InlineData("Český Krumlov", "cesky-krumlov")]
        [InlineData("Český*[] Krumlov", "cesky-krumlov")]
        [InlineData("František Křižík se narodil jako jediný syn venkovského ševce", "frantisek-krizik-se-narodil-jako-jediny-syn-venkovskeho-sevce")]
        [InlineData("Franti**/**//šek Kři???...[][[];;;::žík se n!@#$%^^&&**(*((()))arod%%%%%il jako jed*++++...iný syn venkovského ševce", "frantisek-krizik-se-narodil-jako-jediny-syn-venkovskeho-sevce")]
        public void ToFriendlyUrl_Test(string input, string expectedResult)
        {
            var result = input.ToFriendlyUrl();
            
            Assert.Equal(expectedResult, result);
        }
    }
}
