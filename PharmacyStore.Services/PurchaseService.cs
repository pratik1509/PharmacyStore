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
                InvoiceValue = x.InvoiceValue,
                InvoiceDate = x.InvoiceDate,
                LastPaymentDate = x.LastPaymentDate,
                ChequeNo = x.ChequeNo,
                ChequeDate = x.ChequeDate,
                ChequeAmount = x.ChequeAmount,
                PaidInCash = x.PaidInCash,
                ExtraNote = x.ExtraNote
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
                wholeSellerId = x.wholeSellerId,
                InvoiceNo = x.InvoiceNo,
                InvoiceValue = x.InvoiceValue,
                InvoiceDate = x.InvoiceDate,
                LastPaymentDate = x.LastPaymentDate,
                ChequeNo = x.ChequeNo,
                ChequeDate = x.ChequeDate,
                ChequeAmount = x.ChequeAmount,
                PaidInCash = x.PaidInCash,
                ExtraNote = x.ExtraNote
            });
        }

        public async Task<string> CreateAsync(AddUpdatePurchaseDto purchaseDto)
        {
            return await AddOneAsync(new Purchase
            {
                InvoiceNo = purchaseDto.InvoiceNo,
                InvoiceValue = purchaseDto.InvoiceValue,
                InvoiceDate = purchaseDto.InvoiceDate,
                LastPaymentDate = purchaseDto.LastPaymentDate,
                ChequeNo = purchaseDto.ChequeNo,
                ChequeDate = purchaseDto.ChequeDate,
                ChequeAmount = purchaseDto.ChequeAmount,
                PaidInCash = purchaseDto.PaidInCash,
                ExtraNote = purchaseDto.ExtraNote
            }, _userClaims.Id);
        }

        public async Task<bool> UpdateAsync(AddUpdatePurchaseDto purchaseDto)
        {
            #region update filter

            var updateFilter = Builders<Purchase>.Update
                    .Set(x => x.InvoiceNo, purchaseDto.InvoiceNo)
                    .Set(x => x.InvoiceValue, purchaseDto.InvoiceValue)
                    .Set(x => x.InvoiceDate, purchaseDto.InvoiceDate)
                    .Set(x => x.LastPaymentDate, purchaseDto.LastPaymentDate)
                    .Set(x => x.ChequeNo, purchaseDto.ChequeNo)
                    .Set(x => x.ChequeAmount, purchaseDto.ChequeAmount)
                    .Set(x => x.PaidInCash, purchaseDto.PaidInCash)
                    .Set(x => x.ExtraNote, purchaseDto.ExtraNote);
                    //.Set(x => x.InvoiceNo, purchaseDto.InvoiceNo)
                    .Set(x => x.InvoiceValue, purchaseDto.InvoiceValue);

            #endregion

            return await UpdateOneAsync(purchaseDto.InvoiceNo, updateFilter, _userClaims.Id);
        }

        public async Task<bool> DeleteAsync(string wholeSellerId)
        {
            return await DeleteOneAsync<Purchase>(x => x.Id == wholeSellerId, _userClaims.Id);
        }

    }
}
