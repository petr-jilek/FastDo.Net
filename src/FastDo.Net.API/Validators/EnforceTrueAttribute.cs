using System.ComponentModel.DataAnnotations;

namespace FastDo.Net.Api.Validators
{
    public class EnforceTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;
            if (value.GetType() != typeof(bool))
                return false;
            return (bool)value;
        }
    }
}
