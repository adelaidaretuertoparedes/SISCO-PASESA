using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SICO.Infrastructure.CrossCutting.Validations;

namespace SICO.Application.Core
{
    public class ValidatableDtoBase<TValidator> : IValidatableObject 
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = validationContext.GetService<FluentValidation.IValidator<TValidator>>();    
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage));
        }
    }
}
