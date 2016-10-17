using FluentValidation;
using System.Text.RegularExpressions;

namespace SICO.Infrastructure.CrossCutting.Validations
{
    public static class FluentValidationExtension
    {
        public static IRuleBuilderOptions<T, string> IsAlpha<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(IsAlpha);
        }
        public static IRuleBuilderOptions<T, string> IsAlphaNumeric<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(IsAlphaNumeric);
        }
        private static bool IsAlpha(string value)
        {
            if (value != null)
            {
                return Regex.IsMatch(value, "^[a-zA-ZÁÉÍÑÓÚÜáéíóúüñÑ ]+$");
            }
            else
            {
                return false;
            }
        }
        public static bool IsAlphaNumeric(string value)
        {
            if (value != null && value != "")
            {
                return Regex.IsMatch(value, "^[0-9a-zA-ZÁÉÍÑÓÚÜáéíóúüñÑ ]+$");
            }
            else
            {
                return true;
            }
        }

    }
}
