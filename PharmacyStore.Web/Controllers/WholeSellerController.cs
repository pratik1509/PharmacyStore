using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.WholeSellerDto;
using PharmacyStore.Web.ViewModels.WholeSeller;

namespace PharmacyStore.Web.Controllers
{
    public class WholeSellerController : BaseController
    {
        private readonly IWholeSellerService _wholeSellerService;

        public WholeSellerController(IWholeSellerService wholeSellerService)
        {
            _wholeSellerService = wholeSellerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Success(_mapper.Map<AddUpdateWholeSellerDto>(await _wholeSellerService.Get(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Success(_mapper.Map<List<AddUpdateWholeSellerDto>>(await _wholeSellerService.GetAll()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddUpdateWholeSellerVm model)
        {
            return Success(await _wholeSellerService.Create(_mapper.Map<AddUpdateWholeSellerDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddUpdateWholeSellerVm model)
        {
            return Success(await _wholeSellerService.Update(_mapper.Map<AddUpdateWholeSellerDto>(model)));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            return Success(await _wholeSellerService.Delete(id));
        }
    }
}