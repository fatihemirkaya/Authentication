using Authentication.Domain.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Infrastructure.DI.Installers
{
    public static class TokenInstaller
    {
        public static IServiceCollection AddTokens(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            return services;
        }
    }
}
