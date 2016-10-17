using FluentValidation;

namespace SICO.Application.Main.SizeTypes.Validators
{
    public class UpdateSizeTypeValidator : AbstractValidator<UpdateSizeTypeDto>
    {
        public UpdateSizeTypeValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(1, 50);

            RuleFor(s => s.Id)
                .NotNull();

            //RuleFor(s => s.ClasificationId)
            //    .NotNull();

        }
    }
}
