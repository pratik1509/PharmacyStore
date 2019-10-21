using Common.Mongo.Repository;
using MongoDB.Driver;
using PharmacyStore.Framework.Pagging;
using PharmacyStore.Models;
using PharmacyStore.Services.Abstraction;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.ScheduledCategory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services
{
    public class ScheduledCategoryService : BaseService, IScheduledCategoryService
    {

        public async Task<ScheduledCategoryDto> Get(string id)
        {
            #region filter

            var filter = new FilterDefinitionBuilder<ScheduledCategory>();
            var filterDefination = filter.Empty;

            filterDefination = filterDefination
                & filter.Eq(x => x.Id, id);

            #endregion

            return await GetOneAndProjectAsync(filterDefination, x => new ScheduledCategoryDto
            {
                Id = x.Id,
                Category = x.Category,
            });
        }

        public async Task<List<ScheduledCategoryDto>> GetAll()
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<ScheduledCategory>();
            var filterDefination = filter.Empty;

            #endregion

            return await FindAndProjectAsync(filterDefination, x => new ScheduledCategoryDto
            {
                Id = x.Id,
                Category = x.Category,
            });
        }

        public async Task<string> Create(AddUpdateScheduledCategoryDto dto)
        {
            return await AddOneAsync(new ScheduledCategory
            {
                Category = dto.Category,
            }, _userClaims.Id);
        }

        public async Task<bool> Update(AddUpdateScheduledCategoryDto dto)
        {
            #region update filter

            var updateFilter = Builders<ScheduledCategory>.Update
                    .Set(x => x.Category, dto.Category);

            #endregion

            return await UpdateOneAsync(dto.Id, updateFilter, _userClaims.Id);
        }

        public async Task<bool> Delete(string id)
        {
            return await DeleteOneAsync<ScheduledCategory>(x => x.Id == id, _userClaims.Id);
        }
    }
}
