using Atomicy.Application.Contracts.Persistence;
using Atomicy.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Atomicy.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AtomicyDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AtomicyManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

             services.AddScoped<IDemandTypeRepository, DemandTypeRepository>();
            services.AddScoped<IDemandRepository, DemandRepository>();
            services.AddScoped<IFirmRepository, FirmRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();


            return services;    
        }
    }
}
