using PharmacyStore.Models;
using PharmacyStore.Services.dto.DoctorDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
    public interface IDoctorServices
    {
        Task<string> AddUpdateDoctor(AddUpdateDoctorDto doctor);
        Task<bool> DeleteDoctor(string doctorId);
        Task<Doctor> GetDoctorDetail(string doctorId);
        Task<List<Doctor>> GetDoctorsList();
    }
}
