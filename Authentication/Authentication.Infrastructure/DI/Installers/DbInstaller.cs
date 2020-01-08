using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Authentication.Domain.Repository.Uow;

namespace Authentication.Infrastructure.DI.Installers
{
    public static class DbInstaller
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

    }
}
