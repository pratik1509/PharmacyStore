using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Web.DoctorVm.ViewModels;
using PharmacyStore.Web.ViewModels;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
    public class BaseController : Controller
    {      
        public IActionResult Success<T>(T data)
        {
            return Ok(new ResultVm
            {
                IsSuccess = true,
                Data = data
            });
        }

        public IActionResult Failure<T>(T error)
        {
            return Ok(new ResultVm
            {
                IsSuccess = false,
                Data = error
            });
        }
    }
}