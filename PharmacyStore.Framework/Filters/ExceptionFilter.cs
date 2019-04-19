using Microsoft.AspNetCore.Mvc.Filters;

namespace PharmacyStore.Framework.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
        }
    }
}
