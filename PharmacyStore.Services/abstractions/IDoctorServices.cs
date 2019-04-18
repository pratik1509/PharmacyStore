using PharmacyStore.Models;
using PharmacyStore.Services.dto.DoctorDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
    public interface IDoctorServices
    {
        Task<DoctorDto> Get(string doctorId);
        Task<List<DoctorDto>> GetAll();
        Task<string> Create(AddUpdateDoctorDto doctor);
        Task<bool> Update(AddUpdateDoctorDto doctor);
        Task<bool> Delete(string doctorId);        
    }
}
