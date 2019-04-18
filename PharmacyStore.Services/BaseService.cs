using Common.Mongo.Repository;
using Microsoft.Extensions.DependencyInjection;
using PharmacyStore.Framework.DependencyRegister;
using PharmacyStore.Services.Abstraction;

namespace PharmacyStore.Services
{
    public class BaseService : BaseMongoRepository
    {
        protected readonly IMongoDbContext _db;
        protected readonly IUserClaimsService _userClaims;

        public BaseService() : base(DIEngineContext.ServiceProvider.GetRequiredService<IMongoDbContext>())
        {
            _db = DIEngineContext.ServiceProvider.GetRequiredService<IMongoDbContext>();
            _userClaims = DIEngineContext.ServiceProvider.GetRequiredService<IUserClaimsService>();
        }
    }
}
