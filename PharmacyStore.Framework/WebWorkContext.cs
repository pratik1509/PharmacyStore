using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyStore.Framework
{
    public class WebWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string SiteBaseUrl => "";

        string IWorkContext.SiteBaseUrl => throw new NotImplementedException();

        public void SetCurrentRequestId(string key, string requestId)
        {
            _httpContextAccessor.HttpContext.Items["CurrentRequestId"] = requestId;
        }

        public string GetCurrentRequestId(string key)
        {
            return _httpContextAccessor.HttpContext.Items["CurrentRequestId"]?.ToString();
        }
    }
}
