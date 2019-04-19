using PharmacyStore.Models;

namespace PharmacyStore.Services.dto.RequestResponse
{
    public class RequestResponseLogDto
    {
        public string RequestId { get; set; }
        public string IPAddress { get; set; }
        public RequestLogDto Request { get; set; }
        public ResponseLogDto Response { get; set; }
        public double TimeInSeconds { get; set; } //time taken to serve the request

        public RequestResponseLog ConvertRequestResponseLogDtoToRequestResponse()
        {
            RequestResponseLog log = new RequestResponseLog
            {
                RequestId = RequestId,
                IPAddress = IPAddress,
                Request = new RequestLog
                {
                    Host = Request.Host,
                    Body = Request.Body,
                    Header = Request.Header,
                    Path = Request.Path,
                    QueryStingBody = Request.QueryStingBody
                },
                Response = new ResponseLog
                {
                    Body = Response.Body
                },
                TimeInSeconds = TimeInSeconds
            };

            return log;
        }
    }
}
