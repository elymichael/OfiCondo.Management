namespace OfiCondo.Management.Support.ApiKeyAuthentication
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.DependencyInjection;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Contracts.Authentication;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authorization;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Services.Authentication;
    using System;
    public static class ApiKeyAuthenticationConfiguration
    {
        public static IServiceCollection AddApiKeyAuthentication(this IServiceCollection services)
        {
            // Authorization.
            services.AddSingleton<IAuthorizationHandler, OnlyAdminAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyUserAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyMemberAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, OnlyTestingAuthorizationHandler>();
            // Get Api-Key Information.
            services.AddSingleton<IGetApiKeyService, AppSettingsGetApiKeyService>();

            return services;
        }
    }
}
