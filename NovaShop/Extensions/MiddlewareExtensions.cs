using Serilog;
using Serilog.Events;

namespace NovaShop.Extensions;

public static class MiddlewareExtensions
{
    public static void UseAppMiddleware(this WebApplication app)
    {
        app.UseSerilogRequestLogging(options =>
        {
            options.GetLevel = (httpContext, _, ex) =>
                ex != null
                    ? LogEventLevel.Error
                    : LogEventLevel.Information;
        });
    }
}
