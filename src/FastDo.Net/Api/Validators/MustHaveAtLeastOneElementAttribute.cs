using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FastDo.Net.Api.Validators
{
    public class MustHaveAtLeastOneElementAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is IList { Count: > 0 };
        }
    }
}
