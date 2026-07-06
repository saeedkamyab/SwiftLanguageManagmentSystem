using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLMS.Application.Contracts.InstituteManagment;
using SLMS.Application.Contracts.Persistance;
using SLMS.Persistence.Repositories.Common;
using SLMS.Persistence.Repositories.InstituteManagment;
namespace SLMS.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SLMSDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("connectionString"));
            });

            //services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IInstituteMembershipRepository, InstituteMembershipRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
