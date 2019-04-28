using MongoDB.Driver;
using PharmacyStore.Models;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.WholeSellerDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyStore.Services
{
    public class WholeSellerService : BaseService, IWholeSellerService
    {
        public async Task<WholeSellerDto> Get(string id)
        {
            #region filter

            var filter = new FilterDefinitionBuilder<WholeSeller>();
            var filterDefination = filter.Empty;

            filterDefination = filterDefination
                & filter.Eq(x => x.Id, id);

            #endregion

            return await GetOneAndProjectAsync(filterDefination, x => new WholeSellerDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                VATNo = x.VATNo,
                CSTNo = x.CSTNo,
                DrugLicenseNo = x.DrugLicenseNo,
                TINNo = x.TINNo,
                GSTINNo = x.GSTINNo,
                ContactPersonNo = x.ContactPersonNo,
            });
        }

        public async Task<List<WholeSellerDto>> GetAll()
        {
            // filter is empty because we need all data
            #region filter

            var filter = new FilterDefinitionBuilder<WholeSeller>();
            var filterDefination = filter.Empty;

            #endregion

            return await FindAndProjectAsync(filterDefination, x => new WholeSellerDto
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                VATNo = x.VATNo,
                CSTNo = x.CSTNo,
                DrugLicenseNo = x.DrugLicenseNo,
                TINNo = x.TINNo,
                GSTINNo = x.GSTINNo,
                ContactPersonNo = x.ContactPersonNo,
            });
        }


        public async Task<string> Create(AddUpdateWholeSellerDto dto)
        {
            return await AddOneAsync(new WholeSeller
            {
                Name = dto.Name,
                Address = dto.Address,
                VATNo = dto.VATNo,
                CSTNo = dto.CSTNo,
                DrugLicenseNo = dto.DrugLicenseNo,
                TINNo = dto.TINNo,
                GSTINNo = dto.GSTINNo,
                ContactPersonNo = dto.ContactPersonNo,
            }, _userClaims.Id);
        }

        public async Task<bool> Update(AddUpdateWholeSellerDto dto)
        {
            #region update filter

            var updateFilter = Builders<WholeSeller>.Update
                    .Set(x => x.Name, dto.Name)
                    .Set(x => x.Address, dto.Address)
                    .Set(x => x.VATNo, dto.VATNo)
                    .Set(x => x.CSTNo, dto.CSTNo)
                    .Set(x => x.DrugLicenseNo, dto.DrugLicenseNo)
                    .Set(x => x.GSTINNo, dto.GSTINNo)
                    .Set(x => x.TINNo, dto.TINNo)
                    .Set(x => x.ContactPersonNo, dto.ContactPersonNo);
                    
            #endregion

            return await UpdateOneAsync(dto.Id, updateFilter, _userClaims.Id);
        }


        public async Task<bool> Delete(string id)
        {
            return await DeleteOneAsync<WholeSeller>(x => x.Id == id, _userClaims.Id);
        }
    }
}
