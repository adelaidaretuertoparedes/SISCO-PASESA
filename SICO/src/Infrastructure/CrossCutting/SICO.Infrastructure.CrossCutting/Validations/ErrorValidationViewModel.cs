using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace SICO.Infrastructure.CrossCutting.Validations
{
    public class ErrorValidationViewModel
    {
        public IEnumerable<ModelError> Errors { get; set; }
    }
}
