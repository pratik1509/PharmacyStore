using System.Collections.Generic;
using System.Threading.Tasks;
using PharmacyStore.Models;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.DoctorDto;
using Common.Mongo.Repository;
using PharmacyStore.Services.Abstraction;

namespace PharmacyStore.Services
{
    public class DoctorService : BaseService, IDoctorServices
    {
        private readonly IMongoDbContext _db;
        private readonly IUserClaimsService _userClaims;

        public DoctorService(IMongoDbContext db, IUserClaimsService userClaims) : base(db, userClaims)
        {
            _db = db;
            _userClaims = userClaims;
        }

        public async Task<string> AddUpdateDoctor(AddUpdateDoctorDto doctorDto)
        {
            return await AddOneAsync(new Doctor
            {
                DoctorName = doctorDto.DoctorName,
                Address = doctorDto.Address
            }, _userClaims.Id);
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
