using Microsoft.Azure.Functions.Worker.Http;

namespace GSFunctions.Middleware.Caching;

public class CachedHttpCookies : HttpCookies
{
    private readonly Dictionary<string, IHttpCookie> _cookies = new();

    public override void Append(string name, string value)
    {
        _cookies[name] = new HttpCookie(name, value);
    }

    public override void Append(IHttpCookie cookie)
    {
        _cookies[cookie.Name] = cookie;
    }

    public override IHttpCookie CreateNew()
    {
        return new HttpCookie("", "");

    }
}