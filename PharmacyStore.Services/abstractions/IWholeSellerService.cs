using PharmacyStore.Services.dto.WholeSellerDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
   public interface IWholeSellerService
    {
        Task<WholeSellerDto> Get(string id);
        Task<List<WholeSellerDto>> GetAll();
        Task<string> Create(AddUpdateWholeSellerDto dto);
        Task<bool> Update(AddUpdateWholeSellerDto dto);
        Task<bool> Delete(string id);
    }
}
