using Common.Persistence.ExternalAPICallManagement.APIDto;
using RestSharp;

namespace Common.Persistence.ExternalAPICallManagement.Mapper
{
    public static class RequestMapper
    {
        public static IRestRequest MapRequestToRestRequest(Request request)
        {
            if (request != null)
            {
                var restRequest = new RestRequest(request.Url, (Method)request.Method);
                
                //add headers
                if (request.Headers != null)
                {
                    foreach (var item in request.Headers)
                    {
                        restRequest.AddHeader(item.Key, item.Value);
                    }
                }

                #region addDefaults

                //if no content type sent, add default
                if (!request.Headers.ContainsKey("Content-Type"))
                {
                    restRequest.AddHeader("Content-Type", "application/json");
                }

                //if no accept sent, add default
                if (!request.Headers.ContainsKey("Accept"))
                {
                    restRequest.AddHeader("Accept", "application/json");
                }

                #endregion

                return restRequest;
            }

            return null;
        }

        public static IRestRequest MapRequestToRestRequest<T>(Request request, T data)
        {
            if (request != null)
            {
                var restRequest = MapRequestToRestRequest(request);

                if (data != null)
                {
                    restRequest.AddJsonBody(data);
                }

                return restRequest;
            }

            return null;
        }
    }
}
