using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace SICO.Infrastructure.CrossCutting.Validations
{
    public class ModelStateValidationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ErrorValidationViewModel() {
                    Errors= context.ModelState.Values.SelectMany(x=>x.Errors)
                });
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
                        
        }
        //private void CheckIsValid(ActionExecutedContext context)
        //{
        //    if (!context.ModelState.IsValid)
        //    {
        //        context.Result = new BadRequestObjectResult(context.ModelState);
        //    }
        //} 
    }
}
