namespace PharmacyStore.Services.dto.RequestResponse
{
    public class RequestLogDto
    {
        public string Host { get; set; }
        public string Path { get; set; }
        public string Header { get; set; }
        public object Body { get; set; }
        public string QueryStingBody { get; set; }
    }
}
