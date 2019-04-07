using System.Collections.Generic;
using System.Threading.Tasks;
using PharmacyStore.Models;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.DoctorDto;

namespace PharmacyStore.Services
{
    public class DoctorService : IDoctorServices
    {
        public Task<string> AddUpdateDoctor(AddUpdateDoctorDto doctor)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteDoctor(string doctorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Doctor> GetDoctorDetail(string doctorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Doctor>> GetDoctorsList()
        {
            throw new System.NotImplementedException();
        }
    }
}
