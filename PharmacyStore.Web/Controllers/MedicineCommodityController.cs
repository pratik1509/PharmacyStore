using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.MedicineCommodity;
using PharmacyStore.Web.Doctor.ViewModels;
using PharmacyStore.Web.ViewModels.MedicineCommodity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
    public class MedicineCommodityController : BaseController
    {
        private readonly IMedicineCommodityService _scheduleCommodityService;

        public MedicineCommodityController(IMedicineCommodityService scheduleCommodityService)
        {
            _scheduleCommodityService = scheduleCommodityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Success(_mapper.Map<AddUpdateMedicineCommodityDto>(await _scheduleCommodityService.Get(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<AddUpdateMedicineCommodityDto>>(await _scheduleCommodityService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateMedicineCommodityVm model)
        {
            return Success(await _scheduleCommodityService.Create(_mapper.Map<AddUpdateMedicineCommodityDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdateMedicineCommodityVm model)
        {
            return Success(await _scheduleCommodityService.Update(_mapper.Map<AddUpdateMedicineCommodityDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Success(await _scheduleCommodityService.Delete(id));
        }
    }
}