using FluentValidation;
using SICO.Infrastructure.CrossCutting.Validations;

namespace SICO.Application.Main.Colors.Validators
{
    public class UpdateColorValidator:AbstractValidator<UpdateColorDto>
    {
        public UpdateColorValidator()
        {
            RuleFor(s => s.Name)
               .NotEmpty()
               .Length(0, 50)
               .IsAlphaNumeric();
        }
    }
}
