using ModuleTech.Core.Base.Dtos;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace ModuleTech.Core.Base.Middlewares;

public class HeaderContextMiddleware
{
    private readonly RequestDelegate _next;

    public HeaderContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, HeaderContext headerContext)
    {
        if (context.Request.Headers.TryGetValue("IdentityRefId", out var identityRefId))
            headerContext.IdentityRefId = Guid.TryParse(identityRefId, out var IdentityRefId) ? IdentityRefId : null;

        headerContext.Locale = CultureInfo.CurrentCulture.Parent.Name.ToLower();
        await _next(context);
    }
}