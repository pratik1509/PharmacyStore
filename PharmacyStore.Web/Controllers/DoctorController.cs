using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Web.Doctor.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DoctorController : BaseController
    {
        private readonly IDoctorServices _doctorService;        

        public DoctorController(IMapper mapper, IDoctorServices doctorService)
        {
            _doctorService = doctorService;            
        }

        [HttpGet]
        public async Task<IActionResult> Get(string doctorId)
        {
            return Success(_mapper.Map<DoctorVm>(await _doctorService.Get(doctorId)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<DoctorVm>>(await _doctorService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateDoctorVm addUpdateDoctorVm)
        {
            return Success(await _doctorService.Create(_mapper.Map<AddUpdateDoctorDto>(addUpdateDoctorVm)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdateDoctorVm addUpdateDoctorVm)
        {
            return Success(await _doctorService.Update(_mapper.Map<AddUpdateDoctorDto>(addUpdateDoctorVm)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string doctorId)
        {
            return Success(await _doctorService.Delete(doctorId));
        }
    }
}