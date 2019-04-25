using System.Collections.Generic;
using System.Threading.Tasks;
using PharmacyStore.Models;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.DoctorDto;
using Common.Mongo.Repository;
using PharmacyStore.Services.Abstraction;
using MongoDB.Driver;
using PharmacyStore.Framework.Pagging;

namespace PharmacyStore.Services
{
    public class DoctorService : BaseService, IDoctorService
    {

        public async Task<DoctorDto> Get(string doctorId)
        {
            #region filter

            var filter = new FilterDefinitionBuilder<Doctor>();
            var filterDefination = filter.Empty;

            filterDefination = filterDefination
                & filter.Eq(x => x.Id, doctorId);

            #endregion

            return await GetOneAndProjectAsync(filterDefination, x => new DoctorDto
            {
                DoctorName = x.DoctorName,
                Address = x.Address
            });
        }

        public async Task<List<DoctorDto>> GetAll()
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<Doctor>();
            var filterDefination = filter.Empty;

            #endregion

            return await FindAndProjectAsync(filterDefination, x => new DoctorDto
            {
                DoctorName = x.DoctorName,
                Address = x.Address
            });
        }

        public async Task<PagedList<DoctorDto>> GetAllWithPagging(PagingModel pagingModel)
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<Doctor>();
            var filterDefination = filter.Empty;

            var result = await GetAllWithOrderByAndCountAsync(filterDefination, x => new DoctorDto
            {
                DoctorName = x.DoctorName,
                Address = x.Address
            }, pagingModel.PageSize, pagingModel.Page, x => x.CreatedOn);

            var paggedResult = new PagedList<DoctorDto>(result.Item2, pagingModel.Page, pagingModel.PageSize, result.Item1);

            #endregion

            return paggedResult;
        }

        public async Task<string> Create(AddUpdateDoctorDto doctorDto)
        {
            return await AddOneAsync(new Doctor
            {
                DoctorName = doctorDto.DoctorName,
                Address = doctorDto.Address
            }, _userClaims.Id);
        }

        public async Task<bool> Update(AddUpdateDoctorDto doctorDto)
        {
            #region update filter

            var updateFilter = Builders<Doctor>.Update
                    .Set(x => x.DoctorName, doctorDto.DoctorName)
                    .Set(x => x.Address, doctorDto.Address);

            #endregion

            return await UpdateOneAsync(doctorDto.DoctorId, updateFilter, _userClaims.Id);
        }

        public async Task<bool> Delete(string doctorId)
        {
            return await DeleteOneAsync<Doctor>(x => x.Id == doctorId, _userClaims.Id);
        }
    }
}
