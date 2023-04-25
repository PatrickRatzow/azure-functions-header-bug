using GSFunctions.Middleware.Caching;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(defaults =>
    {
        defaults.UseMiddleware<CachingMiddleware>();
    })
    .Build();

host.Run();
