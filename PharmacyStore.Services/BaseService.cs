using Common.Mongo.Repository;
using PharmacyStore.Services.Abstraction;

namespace PharmacyStore.Services
{
    public class BaseService : BaseMongoRepository
    {
        private readonly IMongoDbContext _db;
        private readonly IUserClaimsService _userClaims;

        public BaseService(IMongoDbContext db, IUserClaimsService userClaims) : base(db)
        {
            _db = db;
            _userClaims = userClaims;
        }
    }
}
