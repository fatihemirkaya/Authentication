using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

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
