using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace SICO.Application.Main.Classifications.Validators
{
    public class CreateClassificationValidator : AbstractValidator<CreateClassificationDto>
    {
        public CreateClassificationValidator()
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
            foreach (char c in Name)
            {
                if (!Char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;
        }
       

    }
}
