using FastDo.Net.Api.Helpers;
using FastDo.Net.Tests.Models;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace FastDo.Net.Tests.Tests.Api.Helpers
{
    public class CommonHelperTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        public void IsInEnum_Test(int value, bool expectedResult)
        {
            var result = CommonHelper.IsInEnum<TestEnum1>(value);

            Assert.Equal(expectedResult, result);
        }
    }
}
