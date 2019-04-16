using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Framework.Filters
{
    public class ModelValidationFilter : ActionFilterAttribute
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                //var Errors = WebHelper.GetCustomModelErrores(actionContext.ModelState);
                //var result = new BadRequestObjectResult(Errors);
                //actionContext.Result = result;
            }
        }
    }
}