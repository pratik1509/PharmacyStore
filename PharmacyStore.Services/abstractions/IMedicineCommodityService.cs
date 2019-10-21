using PharmacyStore.Services.dto.MedicineCommodity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
    public interface IMedicineCommodityService
    {
        Task<MedicineCommodityDto> Get(string id);
        Task<List<MedicineCommodityDto>> GetAll();
        Task<string> Create(AddUpdateMedicineCommodityDto dto);
        Task<bool> Update(AddUpdateMedicineCommodityDto dto);
        Task<bool> Delete(string id);
    }
}
