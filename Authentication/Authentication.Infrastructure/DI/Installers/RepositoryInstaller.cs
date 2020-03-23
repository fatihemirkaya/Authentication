using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Infrastructure.DI.Installers
{
    public static class RepositoryInstaller
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

    }
}
