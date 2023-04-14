using System.ComponentModel.DataAnnotations;

namespace FastDo.Net.Api.Validators
{
    public class IsInEnumAttribute : ValidationAttribute
    {
        public Type EnumType { get; set; }

        public IsInEnumAttribute(Type enumType)
        {
            EnumType = enumType;
        }

        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;
            return Enum.IsDefined(EnumType, value);
        }
    }
}
