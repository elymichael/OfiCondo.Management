namespace OfiCondo.Management.Application
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
