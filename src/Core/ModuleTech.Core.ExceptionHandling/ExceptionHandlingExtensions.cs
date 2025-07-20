using ModuleTech.Core.ExceptionHandling.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ModuleTech.Core.ExceptionHandling;

public static class ExceptionHandlingExtensions
{
    public static IApplicationBuilder AddExceptionHandlingMiddleware(this IApplicationBuilder appBuilder,bool isDetailedErrorEnable=false)
    {
        appBuilder.UseMiddleware<ExceptionHandlingMiddleware>(isDetailedErrorEnable);
        return appBuilder;
    }
}