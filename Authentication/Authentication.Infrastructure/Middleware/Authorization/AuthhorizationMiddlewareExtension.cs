using Microsoft.AspNetCore.Builder;

namespace Authentication.Infrastructure.Middleware
{
    public static class AuthhorizationMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthorizationMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthhorizationMiddleware>();
        }
    }
}
