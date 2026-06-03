using Microsoft.Extensions.DependencyInjection;
using SLMS.Application.Contracts.FileService;
using SLMS.Application.Services;
using System.Reflection;

namespace SLMS.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(MappingProfiles)); //in this way you have to call a specific file name but in below way it find automatically
            //services.AddAutoMapper(Assembly.GetExecutingAssembly()); // in new version we have to use code below instead of the code in this line
            services.AddAutoMapper(cfg =>
            {
            }, Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IMediaUploadService, MediaUploadService>();
            return services;
        }
    }
}
