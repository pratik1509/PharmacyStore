using Microsoft.AspNetCore.Http;
using PharmacyStore.Services.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PharmacyStore.Web.Helpers
{
    public class UserClaims : IUserClaimsService
    {
        private IHttpContextAccessor _contextAccessor;


        public UserClaims(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Id => _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier.ToString())?.Value;

        public string Email => _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.Email.ToString())?.Value;

        public string Name => _contextAccessor.HttpContext.User.Identity.Name;

        public string Type => _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.Role.ToString())?.Value;

        public Dictionary<string, string> GetAllClaims()
        {
            return _contextAccessor.HttpContext.User.Claims
                .ToDictionary(x => x.Type, x => x.Value);
        }
    }
}
