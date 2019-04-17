using Common.Persistence.ExternalAPICallManagement.APIDto;
using RestSharp;

namespace Common.Persistence.ExternalAPICallManagement.Mapper
{
    public static class ResponseMapper
    {
        public static Response MapRestResponseToResponse(IRestResponse restResponse)
        {
            if (restResponse != null)
            {
                return new Response
                {
                    IsSuccessful = restResponse.IsSuccessful,
                    Content = restResponse.Content,
                    ContentLength = restResponse.ContentLength,
                    ErrorException = restResponse.ErrorException,
                    ErrorMessage = restResponse.ErrorMessage,
                    RawBytes = restResponse.RawBytes,
                    ResponseUri = restResponse.ResponseUri,
                    StatusCode = restResponse.StatusCode,
                    StatusDescription = restResponse.StatusDescription
                };
            }

            return null;
        }

        public static Response<T> MapRestResponseToResponse<T>(IRestResponse<T> restResponse)
        {
            if (restResponse != null)
            {
                return new Response<T>
                {
                    IsSuccessful = restResponse.IsSuccessful,
                    Content = restResponse.Content,
                    ContentLength = restResponse.ContentLength,
                    ErrorException = restResponse.ErrorException,
                    ErrorMessage = restResponse.ErrorMessage,
                    RawBytes = restResponse.RawBytes,
                    ResponseUri = restResponse.ResponseUri,
                    StatusCode = restResponse.StatusCode,
                    StatusDescription = restResponse.StatusDescription,
                    Data = restResponse.Data
                };
            }

            return null;
        }
    }
}
