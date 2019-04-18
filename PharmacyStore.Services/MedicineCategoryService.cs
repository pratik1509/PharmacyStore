using Common.Mongo.Repository;
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
        private readonly IMongoDbContext _db;
        private readonly IUserClaimsService _userClaims;

        public MedicineCategoryService(IMongoDbContext db, IUserClaimsService userClaims) : base(db, userClaims)
        {
            _db = db;
            _userClaims = userClaims;
        }

        public Task<MedicineCategory> GetDetail(string id)
        {
            throw new System.NotImplementedException();
        }
        public Task<IPagedList<MedicineCategory>> GeList(PagingModel paging)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> Create(AddUpdateMedicineCategoryDto dto)
        {
            return await AddOneAsync(new MedicineCategory
            {
                Category = dto.Category
            }, _userClaims.Id);
        }

        public async Task<string> Update(AddUpdateMedicineCategoryDto dto)
        {
            //return await UpdateOneAsync(new MedicineCategory
            //{
            //    Category = dto.Category
            //}, _userClaims.Id);
            return null;
        }

        public Task<bool> Delete(string id)
        {
            throw new System.NotImplementedException();
        }

    }
}
