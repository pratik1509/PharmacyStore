using System;
using System.Net;

namespace Common.Persistence.ExternalAPICallManagement.APIDto
{
    public class Response
    {
        public bool IsSuccessful { get; set; }

        public long ContentLength { get; set; }
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public string StatusDescription { get; set; }
        public byte[] RawBytes { get; set; }
        public Uri ResponseUri { get; set; }

        public string ErrorMessage { get; set; }
        public Exception ErrorException { get; set; }
    }

    public class Response<T> : Response
    {
        //
        // Summary:
        //     Deserialized entity data
        public T Data { get; set; }
    }
}
