using RestSharp;

namespace Common.Persistence.ExternalAPICallManagement.RequestResponseLoggerManagement
{
    public interface IRequestResponseLogger
    {
        void Log(IRestRequest request, IRestResponse response);
    }
}