using System.Net;

namespace GSFunctions.Middleware.Caching;

public record CachedResponse(
    string Body,
    IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers,
    HttpStatusCode StatusCode
);