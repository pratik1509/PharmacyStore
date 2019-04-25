using System;
using System.Collections.Generic;
using System.Text;
using PharmacyStore.Services.dto.PurchaseDto;
using PharmacyStore.Services.abstractions;
using System.Threading.Tasks;
using PharmacyStore.Models;
using MongoDB.Driver;
using Common.Mongo.Repository;

namespace PharmacyStore.Services
{
    public class PurchaseService : BaseService, IPurchaseService
    {
        public async Task<PurchaseDto> GetAsync(string wholeSellerId)
        {
            #region filter

            var filter = new FilterDefinitionBuilder<Purchase>();
            var filterDefination = filter.Empty;

            filterDefination = filterDefination
                & filter.Eq(x => x.Id, wholeSellerId);

            #endregion

            return await GetOneAndProjectAsync(filterDefination, x => new PurchaseDto
            {
                InvoiceNo = x.InvoiceNo,
                InvoiceValue = x.InvoiceValue
            });
        }

        public async Task<List<PurchaseDto>> GetAllAsync()
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<Purchase>();
            var filterDefination = filter.Empty;

            #endregion

            return await FindAndProjectAsync(filterDefination, x => new PurchaseDto
            {
                InvoiceNo = x.InvoiceNo,
                InvoiceValue = x.InvoiceValue
            });
        }

        public async Task<string> CreateAsync(AddUpdatePurchaseDto purchaseDto)
        {
            return await AddOneAsync(new Purchase
            {
                InvoiceNo = purchaseDto.InvoiceNo,
                InvoiceValue = purchaseDto.InvoiceValue
            }, _userClaims.Id);
        }

        public async Task<bool> UpdateAsync(AddUpdatePurchaseDto purchaseDto)
        {
            #region update filter

            var updateFilter = Builders<Purchase>.Update
                    //.Set(x => x.InvoiceNo, purchaseDto.InvoiceNo)
                    .Set(x => x.InvoiceValue, purchaseDto.InvoiceValue);

            #endregion

            return await UpdateOneAsync(purchaseDto.InvoiceNo, updateFilter, _userClaims.Id);
        }

        public async Task<bool> DeleteAsync(string WholeSellerId)
        {
            return await DeleteOneAsync<Purchase>(x => x.Id == WholeSellerId, _userClaims.Id);
        }

    }
}
