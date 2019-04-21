using Common.Mongo.Repository;
using MongoDB.Driver;
using PharmacyStore.Framework.Pagging;
using PharmacyStore.Models;
using PharmacyStore.Services.Abstraction;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.Medicine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services
{
    public class MedicineService : BaseService, IMedicineService
    {

        public async Task<MedicineDto> Get(string id)
        {
            #region filter

            var filter = new FilterDefinitionBuilder<Medicine>();
            var filterDefination = filter.Empty;

            filterDefination = filterDefination
                & filter.Eq(x => x.Id, id);

            #endregion

            return await GetOneAndProjectAsync(filterDefination, x => new MedicineDto
            {
                Id = x.Id,
                Category = x.Category,
            });
        }

        public async Task<List<MedicineDto>> GetAll()
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<Medicine>();
            var filterDefination = filter.Empty;

            #endregion

            return await FindAndProjectAsync(filterDefination, x => new MedicineDto
            {
                Id = x.Id,
                Category = x.Category,
            });
        }

        public async Task<string> Create(AddUpdateMedicineDto dto)
        {
            return await AddOneAsync(new Medicine
            {
                Category = dto.Category,
            }, _userClaims.Id);
        }

        public async Task<bool> Update(AddUpdateMedicineDto dto)
        {
            #region update filter

            var updateFilter = Builders<Medicine>.Update
                    .Set(x => x.Category, dto.Category);

            #endregion

            return await UpdateOneAsync(dto.Id, updateFilter, _userClaims.Id);
        }

        public async Task<bool> Delete(string id)
        {
            return await DeleteOneAsync<Medicine>(x => x.Id == id, _userClaims.Id);
        }
    }
}
