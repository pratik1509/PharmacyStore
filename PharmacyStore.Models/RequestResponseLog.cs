using Common.Mongo.Repository;

namespace PharmacyStore.Models
{
    [CollectionName("RequestResponseLogs")]
    public class RequestResponseLog : BaseModel
    {
        public string RequestId { get; set; }
        public string IPAddress { get; set; }
        public RequestLog Request { get; set; }
        public ResponseLog Response { get; set; }
        public double TimeInSeconds { get; set; } //time taken to serve the request
    }

    public class RequestLog
    {
        public string Host { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        public object Body { get; set; }
        public string QueryStingBody { get; set; }
        public long Time { get; set; } //time taken to serve the request
    }

    public class ResponseLog
    {
        public object Body { get; set; }
    }
}
