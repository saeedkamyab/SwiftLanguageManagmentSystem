using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLMS.Application.Contracts.FileService;
using SLMS.Application.Contracts.Identity;
using SLMS.Infrastructure.FileServices;
using SLMS.Infrastructure.Identity;

namespace SLMS.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddScoped<IJwtTokenGenerator,JwtTokenGenerator>();
            return services;
        }
    }
}
