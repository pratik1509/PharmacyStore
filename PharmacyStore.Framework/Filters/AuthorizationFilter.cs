using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace PharmacyStore.Framework.Filters
{
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute(string claimType, string claimValue) : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }

    public class AuthorizationFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public AuthorizationFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string authorizationTokenValue = string.Empty;
            StringValues authorizationTokenValues;
            if (context.HttpContext.Request.Headers.TryGetValue(SystemConstants.AuthorizationTokenKey, out authorizationTokenValues))
            {
                authorizationTokenValue = authorizationTokenValues.FirstOrDefault();
            }


            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                bool allowedAllowAnonymousAttribute = controllerActionDescriptor.MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), inherit: true).Any();
                if(allowedAllowAnonymousAttribute)
                {
                    return;
                }
            }

            //check header value
            //if (string.IsNullOrEmpty(authorizationTokenValue))
            //{
            //    context.Result =new UnauthorizedObjectResult(new ResultVm<string>() { Data= "Missing Authorization-Token" });
            //    return;
            //}

            //decrypt token

            //Serailize token

            //Validate token
        }
    }
}
