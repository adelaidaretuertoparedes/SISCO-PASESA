using SICO.Infrastructure.CrossCutting.ExceptionHandling;
using System;
using System.Collections.Generic;

namespace SICO.Application.Core
{
    public class ApplicationValidationErrorsException : Exception, IInformationErrorException
    {
        IEnumerable<string> _validationErrors;

        public ApplicationValidationErrorsException(IEnumerable<Exception> innerExceptions) : base("Validation exception, check ValidationErrors for more information")
        {
            InnerExceptions = innerExceptions;
        }
        public ApplicationValidationErrorsException(IEnumerable<string> validationErrors) : base("Validation exception, check ValidationErrors for more information")
        {
            _validationErrors = validationErrors;
        }

        public IEnumerable<Exception> InnerExceptions
        {
            get;
            private set;
        }

        public IEnumerable<string> Messages
        {
            get
            {
                return _validationErrors;
            }
            
        }

        public string[] ValidationErrors { get; set; }
    }
}
