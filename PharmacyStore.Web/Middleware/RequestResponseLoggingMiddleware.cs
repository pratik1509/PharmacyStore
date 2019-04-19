using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using PharmacyStore.Services.abstractions;
using PharmacyStore.Services.dto.RequestResponse;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Web.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private RequestResponseLogDto requestResposeDto;
        private readonly IRequestResponseLoggerService _requestResponseLogger;

        public RequestResponseLoggingMiddleware(RequestDelegate next,
            IRequestResponseLoggerService requestResponseLoggerService)
        {
            _next = next;
            _requestResponseLogger = requestResponseLoggerService;
        }

        public async Task Invoke(HttpContext context)
        {
            using (MemoryStream requestBodyStream = new MemoryStream())
            {
                using (MemoryStream responseBodyStream = new MemoryStream())
                {
                    Stream originalRequestBody = context.Request.Body;
                    context.Request.EnableRewind();
                    Stream originalResponseBody = context.Response.Body;

                    try
                    {
                        await context.Request.Body.CopyToAsync(requestBodyStream);
                        requestBodyStream.Seek(0, SeekOrigin.Begin);

                        string requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();

                        requestBodyStream.Seek(0, SeekOrigin.Begin);
                        context.Request.Body = requestBodyStream;

                        context.Response.Body = responseBodyStream;

                        // this is to find the time taken by each requst to video api
                        Stopwatch watch = Stopwatch.StartNew();
                        await _next(context);
                        watch.Stop();

                        responseBodyStream.Seek(0, SeekOrigin.Begin);
                        string responseBodyText = new StreamReader(responseBodyStream).ReadToEnd();

                        responseBodyStream.Seek(0, SeekOrigin.Begin);

                        await responseBodyStream.CopyToAsync(originalResponseBody);

                        await LogRequestResponse(
                                host: context.Request.Host.Host,
                                path: context.Request.Path,
                                querystring: context.Request.QueryString.ToString(),
                                ipAddress: context.Connection.RemoteIpAddress?.MapToIPv4()?.ToString() ?? "unit test",
                                headers: string.Join(",", context.Request.Headers.Select(he => he.Key + ":[" + he.Value + "]").ToList()),
                                requestBodyText: requestBodyText,
                                responseBodyText: responseBodyText,
                                timeInSeconds: watch.Elapsed.TotalSeconds
                            );
                    }
                    catch
                    {
                        byte[] data = System.Text.Encoding.UTF8.GetBytes("Unhandled Error occured, the error has been logged and the persons concerned are notified!! Please, try again in a while.");
                        originalResponseBody.Write(data, 0, data.Length);
                    }
                    finally
                    {
                        context.Request.Body = originalRequestBody;
                        context.Response.Body = originalResponseBody;
                    }
                }
            }
        }

        private async Task LogRequestResponse(string host, string path, string querystring, string ipAddress,
            string headers, string requestBodyText, string responseBodyText, double timeInSeconds)
        {
            //log request
            var requestId = Guid.NewGuid().ToString();

            RequestLogDto requestDto = new RequestLogDto()
            {
                Host = host,
                Path = path,
                QueryStingBody = querystring,
                Header = headers,
                Body = requestBodyText
            };

            ResponseLogDto responseDto = new ResponseLogDto()
            {
                Body = responseBodyText
            };

            requestResposeDto = new RequestResponseLogDto
            {
                RequestId = requestId,
                IPAddress = ipAddress,
                Request = requestDto,
                Response = responseDto,
                TimeInSeconds = timeInSeconds
            };

            await _requestResponseLogger.Add(requestResposeDto);
        }
    }
}
