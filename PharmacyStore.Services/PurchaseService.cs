using System;
using System.Collections.Generic;
using System.Text;
using PharmacyStore.Services.dto.PurchaseDto;
using PharmacyStore.Services.abstractions;
using System.Threading.Tasks;
using PharmacyStore.Models;
using MongoDB.Driver;
using Common.Mongo.Repository;
using PharmacyStore.Services.dto.PurchaseDto;
using System.Linq;
using MongoDB.Bson;

namespace PharmacyStore.Services
{
    public class PurchaseService : BaseService, IPurchaseService
    {
        #region private methods

        private PurchaseMedicine FromPurchaseMedicineModel(AddUpdatePurchaseDto.AddOrUpdatePurchaseMedicineDto model)
        {
            PurchaseMedicine purchaseMedicine = new PurchaseMedicine()
            {
                Id = model.Id,
                MedicineId = model.MedicineId,
                BatchNo = model.BatchNo,
                ExpiryDate = model.ExpiryDate,
                BoxNo = model.BoxNo,
                UnitsPerStrip = model.UnitsPerStrip,
                NoOfStrips = model.NoOfStrips,
                PricePerStrip = model.PricePerStrip,
                MRPPerStrip = model.MRPPerStrip,
                FreeStrips = model.FreeStrips,
                DiscountPercentage = model.DiscountPercentage,
                HSNCode = model.HSNCode,
                VAT = model.VAT,
                AdditionalTax = model.AdditionalTax,
                IGST = model.IGST,
                CGST = model.CGST,
                SGST = model.SGST,
            };

            return purchaseMedicine;
        }

        private AddUpdatePurchaseDto.AddOrUpdatePurchaseMedicineDto ToPurchaseMedicineModel(PurchaseMedicine entity)
        {
            AddUpdatePurchaseDto.AddOrUpdatePurchaseMedicineDto purchaseMedicine = new AddUpdatePurchaseDto.AddOrUpdatePurchaseMedicineDto()
            {
                Id = entity.Id,
                MedicineId = entity.MedicineId,
                BatchNo = entity.BatchNo,
                ExpiryDate = entity.ExpiryDate,
                BoxNo = entity.BoxNo,
                UnitsPerStrip = entity.UnitsPerStrip,
                NoOfStrips = entity.NoOfStrips,
                PricePerStrip = entity.PricePerStrip,
                MRPPerStrip = entity.MRPPerStrip,
                FreeStrips = entity.FreeStrips,
                DiscountPercentage = entity.DiscountPercentage,
                HSNCode = entity.HSNCode,
                VAT = entity.VAT,
                AdditionalTax = entity.AdditionalTax,
                IGST = entity.IGST,
                CGST = entity.CGST,
                SGST = entity.SGST,
            };

            return purchaseMedicine;
        }

        private void ValidatePurchaseMedicines(List<PurchaseMedicine> purchaseMedicinez)
        {
            #region validations

            // at lease one medicine 

            // medicines id mismatch in database

            //if (!string.IsNullOrWhiteSpace(doctorDto.DoctorName))
            //{
            //    throw new PharmacyStoreServiceCustomException("Doctor name is compulsory", string.Empty);
            //}

            #endregion
        }

        #endregion

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

            var entity = new Purchase
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
            };

            entity.Medicines = purchaseDto.Medicines.Select(x => FromPurchaseMedicineModel(x)).ToList();

            entity.Medicines.ForEach(x =>
            {
                x.Id = ObjectId.GenerateNewId().ToString();
            });

            #region validations

            ValidatePurchaseMedicines(entity.Medicines);

            #endregion

            return await AddOneAsync(entity, _userClaims.Id);
        }

        public async Task<bool> UpdateAsync(AddUpdatePurchaseDto purchaseDto)
        {

            var medicines = purchaseDto.Medicines.Select(x => FromPurchaseMedicineModel(x)).ToList();

            #region validations

            ValidatePurchaseMedicines(medicines);

            #endregion

            #region update filter

            var updateFilter = Builders<Purchase>.Update
                    .Set(x => x.InvoiceNo, purchaseDto.InvoiceNo)
                    .Set(x => x.InvoiceValue, purchaseDto.InvoiceValue)
                    .Set(x => x.InvoiceDate, purchaseDto.InvoiceDate)
                    .Set(x => x.LastPaymentDate, purchaseDto.LastPaymentDate)
                    .Set(x => x.ChequeNo, purchaseDto.ChequeNo)
                    .Set(x => x.ChequeAmount, purchaseDto.ChequeAmount)
                    .Set(x => x.PaidInCash, purchaseDto.PaidInCash)
                    .Set(x => x.ExtraNote, purchaseDto.ExtraNote)
                    .Set(x => x.Medicines, medicines);

            #endregion

            return await UpdateOneAsync(purchaseDto.InvoiceNo, updateFilter, _userClaims.Id);
        }

        public async Task<bool> DeleteAsync(string wholeSellerId)
        {
            return await DeleteOneAsync<Purchase>(x => x.Id == wholeSellerId, _userClaims.Id);
        }
    }
}
