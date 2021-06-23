namespace OfiCondo.Management.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using OfiCondo.Management.Application.Constants;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Persistence.Repositories;
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OfiCondoDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(ApplicationConstants.OfiCondoManagementConnectionString)));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRespository<>));

            //services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IEventRepository, EventRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
