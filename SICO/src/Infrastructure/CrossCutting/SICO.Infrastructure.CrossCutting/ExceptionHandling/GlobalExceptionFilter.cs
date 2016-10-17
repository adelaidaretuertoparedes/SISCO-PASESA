using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace SICO.Infrastructure.CrossCutting.ExceptionHandling
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public GlobalExceptionFilter(ILoggerFactory logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger.CreateLogger("Global Exception Filter");
        }

        public void OnException(ExceptionContext context)
        {
            var response = new ErrorViewModel();
            if (context.Exception is IInformationErrorException)
            {
                var informationException = context.Exception as IInformationErrorException;
                response.Messages = informationException.Messages;                
            }
            else {
                response.Messages = new List<string> {"Se ha producido un error inesperado en el sistema, intente nuevamente o consulte con el administrador del sistema por favor."};
            }
            context.Result = new ObjectResult(response)
            {
                StatusCode = 500,
                DeclaredType = typeof(ErrorViewModel)
            };
            _logger.LogError("GlobalExceptionFilter", context.Exception);
        }
    }
}
