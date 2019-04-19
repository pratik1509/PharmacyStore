using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.RequestResponse;
using System.Threading.Tasks;

namespace PharmacyStore.Services
{
    public class RequestResponseLoggerService : BaseService, IRequestResponseLoggerService
    {   
        public async Task Add(RequestResponseLogDto dto)
        {
            await AddOneAsync(dto.ConvertRequestResponseLogDtoToRequestResponse(),
                _userClaims.Id);
        }
    }
}
