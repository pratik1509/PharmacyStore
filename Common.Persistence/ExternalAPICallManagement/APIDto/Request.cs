using System;
using System.Collections.Generic;

namespace Common.Persistence.ExternalAPICallManagement.APIDto
{
    public class Request
    {
        public string Url { get; set; }        
        public Dictionary<string, string> Headers { get; set; }
        public WrapperMethod Method { get; set; }
        public string BaseUrl { get; set; }
    }

    public class Request<T> : Request
    {
        public T Data { get; set; }
    }

    public enum WrapperMethod
    {
        GET = 0,
        POST = 1,
        PUT = 2,
        DELETE = 3,
        HEAD = 4,
        OPTIONS = 5,
        PATCH = 6,
        MERGE = 7,
        COPY = 8
    }
}
