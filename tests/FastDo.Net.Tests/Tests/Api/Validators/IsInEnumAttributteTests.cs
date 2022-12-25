using System.ComponentModel.DataAnnotations;
using FastDo.Net.Api.Validators;
using FastDo.Net.Tests.Models;

namespace FastDo.Net.Tests.Tests.Api.Validators
{
    public class IsInEnumAttributteTests
    {
        class TestClass1
        {
            [IsInEnum(typeof(TestEnum1))]
            public int Value { get; set; }
        }

        class TestClass2
        {
            [IsInEnum(typeof(TestEnum2))]
            public int Value { get; set; }
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(2, false)]
        [InlineData(3, false)]
        [InlineData(4, true)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        public void IsValid_TestEnum1_Test(int value, bool expectedResult)
        {
            var testClass = new TestClass1() { Value = value };

            var context = new ValidationContext(testClass);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(testClass, context, validationResults, true);

            Assert.Equal(expectedResult, isValid);
        }

        [Theory]
        [InlineData(0, false)]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, false)]
        [InlineData(6, false)]
        public void IsValid_TestEnum2_Test(int value, bool expectedResult)
        {
            var testClass = new TestClass2() { Value = value };

            var context = new ValidationContext(testClass);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(testClass, context, validationResults, true);

            Assert.Equal(expectedResult, isValid);
        }
    }
}
