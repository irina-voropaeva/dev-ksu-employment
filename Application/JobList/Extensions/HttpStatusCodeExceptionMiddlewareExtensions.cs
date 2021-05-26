using KsuEmployment.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace KsuEmployment.Api.Extensions
{
    public static class HttpStatusCodeExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpStatusCodeExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpStatusCodeExceptionMiddleware>();
        }
    }
}
