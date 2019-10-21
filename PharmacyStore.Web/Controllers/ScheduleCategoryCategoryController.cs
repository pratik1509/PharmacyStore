using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.ScheduledCategory;
using PharmacyStore.Web.Doctor.ViewModels;
using PharmacyStore.Web.ViewModels.ScheduledCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
    public class ScheduledCategoryController : BaseController
    {
        private readonly IScheduledCategoryService _scheduleCategoryService;

        public ScheduledCategoryController(IScheduledCategoryService scheduleCategoryService)
        {
            _scheduleCategoryService = scheduleCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Success(_mapper.Map<AddUpdateScheduledCategoryDto>(await _scheduleCategoryService.Get(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<AddUpdateScheduledCategoryDto>>(await _scheduleCategoryService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateScheduledCategoryVm model)
        {
            return Success(await _scheduleCategoryService.Create(_mapper.Map<AddUpdateScheduledCategoryDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdateScheduledCategoryVm model)
        {
            return Success(await _scheduleCategoryService.Update(_mapper.Map<AddUpdateScheduledCategoryDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Success(await _scheduleCategoryService.Delete(id));
        }
    }
}