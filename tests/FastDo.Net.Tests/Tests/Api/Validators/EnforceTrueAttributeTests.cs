using System.ComponentModel.DataAnnotations;
using FastDo.Net.Api.Validators;

namespace FastDo.Net.Tests.Tests.Api.Validators
{
    public class EnforceTrueAttributeTests
    {
        class TestClass
        {
            [EnforceTrue]
            public bool Value { get; set; }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsValid_TestEnum1_Test(bool value)
        {
            var testClass = new TestClass() { Value = value };

            var context = new ValidationContext(testClass);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(testClass, context, validationResults, true);

            Assert.Equal(value, isValid);
        }
    }
}
