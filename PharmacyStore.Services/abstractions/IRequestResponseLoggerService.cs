using PharmacyStore.Services.dto.RequestResponse;
using System.Threading.Tasks;

namespace PharmacyStore.Services.abstractions
{
    public interface IRequestResponseLoggerService
    {
        Task Add(RequestResponseLogDto dto);
    }
}
