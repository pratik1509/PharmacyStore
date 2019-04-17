using Common.Persistence.LogManagement;
using RestSharp;
using System;
using System.Linq;

namespace Common.Persistence.ExternalAPICallManagement.RequestResponseLoggerManagement
{
    public class RequestResponseLogger : RestClient, IRequestResponseLogger
    {
        private readonly ILoggerService _loggerService;
        private readonly bool _isEnabled; //log request response only if enabled

        public RequestResponseLogger(ILoggerService loggerService, 
            string baseUrl, 
            bool isEnabled = true)
        {
            _loggerService = loggerService;
            BaseUrl = new Uri(baseUrl);
            _isEnabled = isEnabled; //log request response only if enabled
        }

        public void Log(IRestRequest request, IRestResponse response)
        {
            if (_isEnabled) //log request response only if enabled
            {
                //if status not Ok log error
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    LogError(BaseUrl, request, response);
                }

                //if success log request resposne
                LogRequestResponse(BaseUrl, request, response);
            }
        }

        private void LogError(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, the status code, and the parameters.
            string info = "Request to " + BaseUrl.AbsoluteUri + request.Resource + " failed with status code " + response.StatusCode + ", parameters: "
            + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            Exception ex;
            if (response != null && response.ErrorException != null)
            {
                ex = response.ErrorException;
            }
            else
            {
                ex = new Exception(info);
                info = string.Empty;
            }

            //Log the exception and info message
            _loggerService.Error(ex, info);
        }

        private void LogRequestResponse(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, the status code, and the parameters.
            string info = "Request to " + BaseUrl.AbsoluteUri + request.Resource + " status code " + response.StatusCode + ", parameters: "
            + parameters + ", and content: " + response.Content;

            //Log the exception and info message
            _loggerService.Information(info);
        }
    }
}
