﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PharmacyStore.Framework;
using PharmacyStore.Framework.DependencyRegister;
using PharmacyStore.Framework.Filters;
using PharmacyStore.Web.ViewModels;

namespace PharmacyStore.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ModelValidationFilter]
    [Authorization("", "")]
    [ExceptionFilter]
    public class BaseController : ControllerBase
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
        protected IActionResult Failure<T>(T error)
        {
            return Ok(new ResultVm<T>
            {
                IsSuccess = false,
                Data = error
            });
        }
    }
}