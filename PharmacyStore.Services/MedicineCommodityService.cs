using Common.Mongo.Repository;
using MongoDB.Driver;
using PharmacyStore.Framework.Pagging;
using PharmacyStore.Models;
using PharmacyStore.Services.Abstraction;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.MedicineCommodity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services
{
    public class MedicineCommodityService : BaseService, IMedicineCommodityService
    {

        public async Task<MedicineCommodityDto> Get(string id)
        {
            #region filter

            var filter = new FilterDefinitionBuilder<MedicineCommodity>();
            var filterDefination = filter.Empty;

            filterDefination = filterDefination
                & filter.Eq(x => x.Id, id);

            #endregion

            return await GetOneAndProjectAsync(filterDefination, x => new MedicineCommodityDto
            {
                Id = x.Id,
                Commodity = x.Commodity,
            });
        }

        public async Task<List<MedicineCommodityDto>> GetAll()
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<MedicineCommodity>();
            var filterDefination = filter.Empty;

            #endregion

            return await FindAndProjectAsync(filterDefination, x => new MedicineCommodityDto
            {
                Id = x.Id,
                Commodity = x.Commodity,
            });
        }

        public async Task<string> Create(AddUpdateMedicineCommodityDto dto)
        {
            return await AddOneAsync(new MedicineCommodity
            {
                Commodity = dto.Commodity,
            }, _userClaims.Id);
        }

        public async Task<bool> Update(AddUpdateMedicineCommodityDto dto)
        {
            #region update filter

            var updateFilter = Builders<MedicineCommodity>.Update
                    .Set(x => x.Commodity, dto.Commodity);

            #endregion

            return await UpdateOneAsync(dto.Id, updateFilter, _userClaims.Id);
        }

        public async Task<bool> Delete(string id)
        {
            return await DeleteOneAsync<MedicineCommodity>(x => x.Id == id, _userClaims.Id);
        }
    }
}
