using Authentication.Domain.Repository.Repository;
using Authentication.Domain.Repository.Uow;
using Authentication.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Infrastructure.DI.Installers
{
    public static class  RepositoryInstaller 
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

    }
}
