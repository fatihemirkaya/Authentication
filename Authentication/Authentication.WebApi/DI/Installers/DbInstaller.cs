using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Authentication.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.WebApi.DI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            IServiceCollection serviceCollection = services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
        }
    }
}
