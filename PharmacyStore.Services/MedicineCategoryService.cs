using Common.Mongo.Repository;
using MongoDB.Driver;
using PharmacyStore.Framework.Pagging;
using PharmacyStore.Models;
using PharmacyStore.Services.Abstraction;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.MedicineCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services
{
    public class MedicineCategoryService : BaseService, IMedicineCategoryService
    {

        public async Task<MedicineCategoryDto> Get(string id)
        {
            #region filter

            var filter = new FilterDefinitionBuilder<MedicineCategory>();
            var filterDefination = filter.Empty;

            filterDefination = filterDefination
                & filter.Eq(x => x.Id, id);

            #endregion

            return await GetOneAndProjectAsync(filterDefination, x => new MedicineCategoryDto
            {
                Id = x.Id,
                Category = x.Category,
            });
        }

        public async Task<List<MedicineCategoryDto>> GetAll()
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<MedicineCategory>();
            var filterDefination = filter.Empty;

            #endregion

            return await FindAndProjectAsync(filterDefination, x => new MedicineCategoryDto
            {
                Id = x.Id,
                Category = x.Category,
            });
        }

        public async Task<string> Create(AddUpdateMedicineCategoryDto dto)
        {
            return await AddOneAsync(new MedicineCategory
            {
                Category = dto.Category,
            }, _userClaims.Id);
        }

        public async Task<bool> Update(AddUpdateMedicineCategoryDto dto)
        {
            #region update filter

            var updateFilter = Builders<MedicineCategory>.Update
                    .Set(x => x.Category, dto.Category);

            #endregion

            return await UpdateOneAsync(dto.Id, updateFilter, _userClaims.Id);
        }

        public async Task<bool> Delete(string id)
        {
            return await DeleteOneAsync<MedicineCategory>(x => x.Id == id, _userClaims.Id);
        }
    }
}
