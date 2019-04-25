using PharmacyStore.Services.dto.Medicine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
    public interface IMedicineService
    {
        Task<MedicineDto> Get(string id);
        Task<List<MedicineDto>> GetAll();
        Task<string> Create(AddUpdateMedicineDto dto);
        Task<bool> Update(AddUpdateMedicineDto dto);
        Task<bool> Delete(string id);
    }
}
