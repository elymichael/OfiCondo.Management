namespace OfiCondo.Management.Persistence.InterationTests.Base
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using OfiCondo.Management.Identity;
    using System;
    using System.Net.Http;
    public class CustomWebApplicationFactory<TStartup>: WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                // Adding Database Context.
                services.AddDbContext<OfiCondoDbContext>(options =>
                {
                    options.UseInMemoryDatabase("OfiCondoDbContextInMemoryTest")
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });
                // Adding Database Identity Context.
                services.AddDbContext<OfiCondoIdentityDbContext>(options =>
                {
                    options.UseInMemoryDatabase("OfiCondoIdentityDbContextInMemoryTest");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                // Get context database.
                var context = scopedServices.GetRequiredService<OfiCondoDbContext>();
                context.Database.EnsureCreated();
                var contextIdentity = scopedServices.GetRequiredService<OfiCondoIdentityDbContext>();
                contextIdentity.Database.EnsureCreated();

                // Create logger.
                var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                try
                {
                    // Initialize Database.
                    ContextFactory.InitializeDbForTests(context);
                    ContextFactory.InitializeDbForTests(contextIdentity);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                }
            });
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }
    }
}
