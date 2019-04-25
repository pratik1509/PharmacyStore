using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.MedicineCategory;
using PharmacyStore.Services.dto.Medicine;
using PharmacyStore.Web.Doctor.ViewModels;
using PharmacyStore.Web.ViewModels.MedicineCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Controllers
{
    public class MedicineController : BaseController
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Success(_mapper.Map<AddUpdateMedicineDto>(await _medicineService.Get(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<AddUpdateMedicineDto>>(await _medicineService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateMedicineVm model)
        {
            return Success(await _medicineService.Create(_mapper.Map<AddUpdateMedicineDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdateMedicineVm model)
        {
            return Success(await _medicineService.Update(_mapper.Map<AddUpdateMedicineDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Success(await _medicineService.Delete(id));
        }
    }
}