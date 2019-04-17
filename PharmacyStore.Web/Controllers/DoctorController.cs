using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Web.DoctorVm.ViewModels;
using PharmacyStore.Web.ViewModels;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
	
	public class DoctorController : BaseController
    {
        private readonly IDoctorServices _doctorService;        

        public DoctorController(IMapper mapper, IDoctorServices doctorService)
        {
            _doctorService = doctorService;            
        }

		[HttpPost]
        public async Task<IActionResult> AddUpdateDoctor(AddUpdateDoctorVm addUpdateDoctorVm)
        {
            return Success(await _doctorService.AddUpdateDoctor(_mapper.Map<AddUpdateDoctorDto>(addUpdateDoctorVm)));
        }
    }
}