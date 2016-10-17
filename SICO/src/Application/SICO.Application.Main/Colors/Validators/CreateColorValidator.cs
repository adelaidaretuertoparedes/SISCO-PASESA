using FluentValidation;
using SICO.Infrastructure.CrossCutting.Validations;
using System.Text.RegularExpressions;

namespace SICO.Application.Main.Colors.Validators
{
    public class CreateColorValidator:AbstractValidator<CreateColorDto>
    {
        public CreateColorValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(0, 50)
                .IsAlphaNumeric();
        }
    }
}
