using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Persistence.ExternalAPICallManagement.APIDto;

namespace Common.Persistence.ExternalAPICallManagement
{
    public interface IApiCallWrapperService
    {
        Task<Response<R>> ExecuteTaskAsync<T, R>(Request<T> request);
        Task<Response<T>> ExecuteTaskAsync<T>(Request request);
    }
}