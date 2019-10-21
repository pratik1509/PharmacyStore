using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.MedicineCategory;
using PharmacyStore.Web.Doctor.ViewModels;
using PharmacyStore.Web.ViewModels.MedicineCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
    public class MedicineCategoryController : BaseController
    {
        private readonly IMedicineCategoryService _medicineCategoryService;

        public MedicineCategoryController(IMedicineCategoryService medicineCategoryService)
        {
            _medicineCategoryService = medicineCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Success(_mapper.Map<AddUpdateMedicineCategoryDto>(await _medicineCategoryService.Get(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<AddUpdateMedicineCategoryDto>>(await _medicineCategoryService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateMedicineCategoryVm model)
        {
            return Success(await _medicineCategoryService.Create(_mapper.Map<AddUpdateMedicineCategoryDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdateMedicineCategoryVm model)
        {
            return Success(await _medicineCategoryService.Update(_mapper.Map<AddUpdateMedicineCategoryDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Success(await _medicineCategoryService.Delete(id));
        }
    }
}