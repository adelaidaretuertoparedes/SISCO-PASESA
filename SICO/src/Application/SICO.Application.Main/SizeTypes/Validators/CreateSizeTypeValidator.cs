using FluentValidation;

namespace SICO.Application.Main.SizeTypes.Validators
{
    public class CreateSizeTypeValidator: AbstractValidator<CreateSizeTypeDto>
    {
        public CreateSizeTypeValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(1, 50);

            //RuleFor(s => s.Description)
            //    .LessThanOrEqualTo(100);

            //RuleFor(s => s.ClasificationId)
            //    .NotNull();

            //Property(x=>x.Name).HasMaxLength(100).HasUniqueConstraint("UN_Name");
        }
    }
}
