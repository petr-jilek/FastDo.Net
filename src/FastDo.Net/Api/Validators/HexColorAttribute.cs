using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FastDo.Net.Api.Validators
{
    public class HexColorAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is null)
                return false;
            var hexColor = value.ToString();
            if (hexColor is null)
                return false;
            var hexColorRegex = new Regex("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
            if (hexColorRegex.IsMatch(hexColor) == false)
                return false;
            return true;
        }
    }
}
