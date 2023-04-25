#nullable enable
using System.Net;
using System.Text;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace GSFunctions.Middleware.Caching
{
    public class CachingMiddleware : IFunctionsWorkerMiddleware
    {
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var cachedResponse = new CachedResponse(
                "[]",
                new Dictionary<string, IEnumerable<string>>
                {
                    { "Content-Type", new List<string>() { "application/json" } }
                },
                HttpStatusCode.OK
            );

            var cookies = new CachedHttpCookies();
            var headers = new HttpHeadersCollection();
            headers.Add("X-Text-Type", "json");
            var body = Encoding.UTF8.GetBytes(cachedResponse.Body);
            var stream = new MemoryStream(body);

            context.GetInvocationResult().Value = new CachedHttpResponseData(context, cookies)
            {
                Body = stream,
                Headers = headers,
                StatusCode = cachedResponse.StatusCode
            };
        }
    }
}