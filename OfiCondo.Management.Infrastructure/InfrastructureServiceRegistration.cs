namespace OfiCondo.Management.Infrastructure
{    
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using OfiCondo.Management.Application.Contracts.Infrastructure;
    using OfiCondo.Management.Application.Models.Mail;
    using OfiCondo.Management.Infrastructure.FileExport;
    using OfiCondo.Management.Infrastructure.Mail;

    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
