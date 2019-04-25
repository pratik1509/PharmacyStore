using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PharmacyStore.Services.dto.PurchaseDto;

namespace PharmacyStore.Services.abstractions
{
    public interface IPurchaseService
    {
        Task<PurchaseDto> GetAsync(string doctorId);
        Task<List<PurchaseDto>> GetAllAsync();
        Task<string> CreateAsync(AddUpdatePurchaseDto purchase);
        Task<bool> UpdateAsync(AddUpdatePurchaseDto purchase);
        Task<bool> DeleteAsync(string doctorId);

    }
}
