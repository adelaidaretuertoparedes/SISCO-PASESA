using FluentValidation;
using SICO.Infrastructure.CrossCutting.Validations;
using System.Text.RegularExpressions;

namespace SICO.Application.Main.Trademarks.Validators
{
    public class UpdateTrademarkValidator : AbstractValidator<UpdateTrademarkDto>
    {
        public UpdateTrademarkValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(1, 50)
                .IsAlpha();

            RuleFor(s => s.ShortName)
                .Length(0, 50)
                .IsAlphaNumeric();

            RuleFor(s => s.Owner)
                .Length(0, 100)
                .Must(IsAlphaWithSymbol);
        }

        public bool IsAlphaWithSymbol(string Owner)
        {
            if (Owner != null && Owner != "")
            {
                return Regex.IsMatch(Owner, "^[a-zA-ZÁÉÍÑÓÚÜáéíóúüñÑ .,/-]+$");
            }
            else
            {
                return true;
            }
        }
    }
}
