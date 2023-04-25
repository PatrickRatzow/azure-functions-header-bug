using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace GSFunctions.Middleware.Caching;

public class CachedHttpResponseData : HttpResponseData
{
    public CachedHttpResponseData(FunctionContext functionContext, HttpCookies cookies) : base(functionContext)
    {
        Cookies = cookies;
    }

    public override HttpStatusCode StatusCode { get; set; }
    public override HttpHeadersCollection Headers { get; set; }
    public override Stream Body { get; set; }
    public override HttpCookies Cookies { get; }
}