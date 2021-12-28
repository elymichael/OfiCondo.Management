namespace OfiCondo.Management.MemoryCache
{
    using Microsoft.Extensions.DependencyInjection;
    public static class MemoryCacheRegistration
    {
        public static IServiceCollection ConfigureCaching(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped(typeof(ICacheService<>), typeof(MemoryCacheService<>));

            return services;
        }
    }
}
