using FluentValidation;
using System;

namespace SICO.Application.Main.Classifications.Validators
{
    public class UpdateClassificationValidator : AbstractValidator<UpdateClassificationDto>
    {
        public UpdateClassificationValidator()
        {

            RuleFor(s => s.Name)
                .NotEmpty()
                .Length(1, 50)
                .Must(IsAllLettersOrSpaces);

            RuleFor(s => s.ArticleGroupCode)
                .NotEmpty()
                .NotNull();
        }

        public static bool IsAllLettersOrSpaces(string Name)
        {
            foreach (char c in Name){
                if (!Char.IsLetter(c) && c != ' ')
                    return false;
             }
             return true;
        }


    }
}
