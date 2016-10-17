using FluentValidation;

namespace SICO.Application.Main.Sizes.Validators
{
    public class CreateSizeValidator: AbstractValidator<CreateSizeDto>
    {
        public CreateSizeValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(1, 50);

            //RuleFor(s => s.LegacyCode)
            //    .NotEmpty()
            //    .Length(1, 3);
            
        }
    }
}
