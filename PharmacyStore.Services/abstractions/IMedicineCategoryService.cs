using PharmacyStore.Services.dto.MedicineCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
    public interface IMedicineCategoryService
    {
        Task<MedicineCategoryDto> Get(string id);
        Task<List<MedicineCategoryDto>> GetAll();
        Task<string> Create(AddUpdateMedicineCategoryDto dto);
        Task<bool> Update(AddUpdateMedicineCategoryDto dto);
        Task<bool> Delete(string id);
    }
}
