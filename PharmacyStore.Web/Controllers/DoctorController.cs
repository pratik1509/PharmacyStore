using AutoMapper;
using Common.Persistence.SecurityManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Framework.Pagging;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.DoctorDto;
using PharmacyStore.Web.Doctor.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Success(_mapper.Map<DoctorVm>(await _doctorService.Get(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<DoctorVm>>(await _doctorService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllWithPagging(PagingModel pagingModel)
        {
            var result = await _doctorService.GetAllWithPagging(pagingModel);
            var responseModel = _mapper.Map<List<DoctorVm>>(result.Data);
            var paggedResult = new PagedList<DoctorVm>(responseModel, pagingModel.Page, pagingModel.PageSize, result.Paging.TotalCount);

            return Success(paggedResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateDoctorVm model)
        {
            return Success(await _doctorService.Create(_mapper.Map<AddUpdateDoctorDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdateDoctorVm model)
        {
            return Success(await _doctorService.Update(_mapper.Map<AddUpdateDoctorDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Success(await _doctorService.Delete(id));
        }
    }
}