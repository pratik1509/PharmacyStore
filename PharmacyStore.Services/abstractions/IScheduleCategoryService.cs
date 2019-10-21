using PharmacyStore.Services.dto.ScheduledCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
    public interface IScheduledCategoryService
    {
        Task<ScheduledCategoryDto> Get(string id);
        Task<List<ScheduledCategoryDto>> GetAll();
        Task<string> Create(AddUpdateScheduledCategoryDto dto);
        Task<bool> Update(AddUpdateScheduledCategoryDto dto);
        Task<bool> Delete(string id);
    }
}
