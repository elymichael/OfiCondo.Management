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

            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<ICondominiumRepository, CondominiumRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IFeeRepository, FeeRepository>();
            services.AddScoped<IPayeeRepository, PayeeRepository>();
            services.AddScoped<IIncomeRepository, IncomeRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();

            return services;
        }
    }
}
