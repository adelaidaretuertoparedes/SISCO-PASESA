using FluentValidation;

namespace SICO.Application.Main.Sizes.Validators
{
    public class UpdateSizeValidator : AbstractValidator<UpdateSizeDto>
    {

        public UpdateSizeValidator()
        {
            RuleFor(s => s.Id)
                .NotNull();

            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(1, 50);

            //RuleFor(s => s.Order)
            //    .NotNull();

        }
    }
}
