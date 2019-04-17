using Common.Persistence.ExternalAPICallManagement.APIDto;
using Common.Persistence.ExternalAPICallManagement.Mapper;
using Common.Persistence.ExternalAPICallManagement.RequestResponseLoggerManagement;
using RestSharp;
using System.Threading.Tasks;

namespace Common.Persistence.ExternalAPICallManagement
{
    public class ApiCallWrapperService : RestClient, IApiCallWrapperService
    {
        //private readonly IRequestResponseLogger _requestResponseLogger;
        private RestClient _client;
        public ApiCallWrapperService()//IRequestResponseLogger requestResponseLogger)
        {
            //_requestResponseLogger = requestResponseLogger;
        }

        #region public members

        public async Task<Response<R>> ExecuteTaskAsync<T, R>(Request<T> request)
        {
            try
            {
                IRestResponse<R> restResponse = null;
                
                //generating rest request
                var restRequest =
                    RequestMapper.MapRequestToRestRequest(request, request.Data);

                //execute request
                restResponse = await ExecuteRequest<R>(restRequest, request.Method, request.BaseUrl);

                //check for time out and log request/response/error
                //_requestResponseLogger.Log(restRequest, restResponse);

                //generate response from RestResponse
                return ResponseMapper.MapRestResponseToResponse(restResponse);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<Response<T>> ExecuteTaskAsync<T>(Request request)
        {
            IRestResponse<T> restResponse = null;

            //generating rest request
            var restRequest =
                RequestMapper.MapRequestToRestRequest(request);

            //execute request
            restResponse = await ExecuteRequest<T>(restRequest, request.Method, request.BaseUrl);

            //check for time out and log request/response/error
            //_requestResponseLogger.Log(restRequest, restResponse);

            //generate response from RestResponse
            return ResponseMapper.MapRestResponseToResponse(restResponse);
        }

        #endregion

        #region members

        private async Task<IRestResponse<T>> ExecuteRequest<T>(IRestRequest restRequest, WrapperMethod method,string baseUrl)
        {
            _client = new RestClient(baseUrl);
            switch (method)
            {
                case WrapperMethod.GET:
                    return await _client.ExecuteGetTaskAsync<T>(restRequest);
                case WrapperMethod.POST:
                    return await _client.ExecutePostTaskAsync<T>(restRequest);                    
                case WrapperMethod.PUT:
                    return await _client.ExecutePostTaskAsync<T>(restRequest);                    
                case WrapperMethod.DELETE:
                    return await _client.ExecuteGetTaskAsync<T>(restRequest);                    
                default:
                    return null;
            }
        }

        #endregion
    }
}
