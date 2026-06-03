using Microsoft.Extensions.DependencyInjection;
using SLMS.Application.Contracts.FileService;
using SLMS.Infrastructure.FileServices;

namespace SLMS.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IFileStorageService, FileStorageService>();
            return services;
        }
    }
}
