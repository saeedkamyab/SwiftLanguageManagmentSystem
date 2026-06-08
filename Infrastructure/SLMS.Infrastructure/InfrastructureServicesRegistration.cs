using Microsoft.Extensions.DependencyInjection;
using SLMS.Application.Contracts.FileService;
using SLMS.Application.Contracts.Identity;
using SLMS.Infrastructure.FileServices;
using SLMS.Infrastructure.Identity;

namespace SLMS.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            return services;
        }
    }
}
