using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Globomantics.Filters
{
    public class ModelValidationFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ViewResult()
                {
                    ViewData = ((Controller)context.Controller).ViewData,
                    TempData = ((Controller)context.Controller).TempData,
                    StatusCode = 400
                };
            }
        }
    }
}
