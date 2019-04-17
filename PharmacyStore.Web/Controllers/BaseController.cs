using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PharmacyStore.Framework.DependencyRegister;
using PharmacyStore.Framework.Filters;
using PharmacyStore.Web.ViewModels;

namespace PharmacyStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ModelValidationFilter]
    [Authorization("", "")]
    [ExceptionFilter]
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;

        public BaseController()
        {
            _mapper = DIEngineContext.ServiceProvider.GetRequiredService<IMapper>(); ;
        }


        [NonAction]
        protected IActionResult Success<T>(T data)
        {
            return Ok(new ResultVm<T>
            {
                IsSuccess = true,
                Data = data
            });
        }

        [NonAction]
        private IActionResult Failure<T>(T error)
        {
            return Ok(new ResultVm<T>
            {
                IsSuccess = false,
                Data = error
            });
        }
    }
}