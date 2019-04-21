using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

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
                var errors = actionContext.ModelState.Values.SelectMany(x => x.Errors).ToList();
                //var Errors = WebHelper.GetCustomModelErrores(actionContext.ModelState);
                var result = new BadRequestObjectResult(new ResultVm<object> { Data = errors });
                actionContext.Result = result;
            }
        }
    }
}