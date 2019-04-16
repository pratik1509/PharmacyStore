using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

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
            //var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            //if (!hasClaim)
            //{
            //    context.Result = new ForbidResult();
            //}
        }
    }
}
