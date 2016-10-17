using FluentValidation;

namespace SICO.Application.Main.DetailsSizeType.Validators
{
    public class CreateDetailSizeTypeValidator: AbstractValidator<CreateDetailSizeTypeDto>
    {
        public CreateDetailSizeTypeValidator()
        {

            RuleFor(s => s.SizeId)
                .NotNull();

            RuleFor(s => s.SizeTypeId)
                .NotNull();

            RuleFor(s => s.Order)
                .NotNull();
        }
    }
}
