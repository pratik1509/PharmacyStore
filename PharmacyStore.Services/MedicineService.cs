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
                ScheduleCategoryId = x.ScheduleCategoryId,
                MedicineCategoryId = x.MedicineCategoryId,
                MedicineCommodityId = x.MedicineCommodityId,
                Name = x.Name,
                GenericName = x.GenericName,
                Manufacturer = x.Manufacturer,
                DiscountPercentage = x.DiscountPercentage,
                HSNCode = x.HSNCode,
                Price = x.Price,
                VAT = x.VAT,
                AdditionalTax = x.AdditionalTax,
                IGST = x.IGST,
                CGST = x.CGST,
                SGST = x.SGST,
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
                ScheduleCategoryId = x.ScheduleCategoryId,
                MedicineCategoryId = x.MedicineCategoryId,
                MedicineCommodityId = x.MedicineCommodityId,
                Name = x.Name,
                GenericName = x.GenericName,
                Manufacturer = x.Manufacturer,
                DiscountPercentage = x.DiscountPercentage,
                HSNCode = x.HSNCode,
                Price = x.Price,
                VAT = x.VAT,
                AdditionalTax = x.AdditionalTax,
                IGST = x.IGST,
                CGST = x.CGST,
                SGST = x.SGST,
            });
        }

        public async Task<string> Create(AddUpdateMedicineDto dto)
        {
            return await AddOneAsync(new Medicine
            {
                ScheduleCategoryId = dto.ScheduleCategoryId,
                MedicineCategoryId = dto.MedicineCategoryId,
                MedicineCommodityId = dto.MedicineCommodityId,
                Name = dto.Name,
                GenericName = dto.GenericName,
                Manufacturer = dto.Manufacturer,
                DiscountPercentage = dto.DiscountPercentage,
                HSNCode = dto.HSNCode,
                Price = dto.Price,
                VAT = dto.VAT,
                AdditionalTax = dto.AdditionalTax,
                IGST = dto.IGST,
                CGST = dto.CGST,
                SGST = dto.SGST,
            }, _userClaims.Id);
        }

        public async Task<bool> Update(AddUpdateMedicineDto dto)
        {
            #region update filter

            var updateFilter = Builders<Medicine>.Update
                    .Set(x => x.ScheduleCategoryId, dto.ScheduleCategoryId)
                    .Set(x => x.MedicineCategoryId, dto.MedicineCategoryId)
                    .Set(x => x.MedicineCommodityId, dto.MedicineCommodityId)
                    .Set(x => x.Name, dto.Name)
                    .Set(x => x.GenericName, dto.GenericName)
                    .Set(x => x.Manufacturer, dto.Manufacturer)
                    .Set(x => x.DiscountPercentage, dto.DiscountPercentage)
                    .Set(x => x.HSNCode, dto.HSNCode)
                    .Set(x => x.Price, dto.Price)
                    .Set(x => x.VAT, dto.VAT)
                    .Set(x => x.AdditionalTax, dto.AdditionalTax)
                    .Set(x => x.IGST, dto.IGST)
                    .Set(x => x.CGST, dto.CGST)
                    .Set(x => x.SGST, dto.SGST);

            #endregion

            return await UpdateOneAsync(dto.Id, updateFilter, _userClaims.Id);
        }

        public async Task<bool> Delete(string id)
        {
            return await DeleteOneAsync<Medicine>(x => x.Id == id, _userClaims.Id);
        }
    }
}
