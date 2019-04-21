using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.PurchaseDto;
using PharmacyStore.Web.ViewModels.Purchase;


namespace PharmacyStore.Web.Controllers
{
    public class PurchaseController : BaseController
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Success(_mapper.Map<PurchaseVm>(await _purchaseService.GetAsync(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<PurchaseVm>>(await _purchaseService.GetAllAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdatePurchaseVm model)
        {
            return Success(await _purchaseService.CreateAsync(_mapper.Map<AddUpdatePurchaseDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdatePurchaseVm model)
        {
            return Success(await _purchaseService.UpdateAsync(_mapper.Map<AddUpdatePurchaseDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Success(await _purchaseService.DeleteAsync(id));
        }
    }
}