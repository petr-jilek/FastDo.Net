using System.ComponentModel.DataAnnotations;

namespace ApiCommon.API.Validators
{
    public class EnforceTrueAttribute: ValidationAttribute
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
