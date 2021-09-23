namespace OfiCondo.Management.Support.ApiKeyAuthentication.Services.Authentication
{
    using Microsoft.Extensions.Options;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Contracts.Authentication;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authentication;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Model;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class AppSettingsGetApiKeyService : IGetApiKeyService
    {
        private readonly IDictionary<string, ApiKey> _apiKey;
        private readonly SecurityKeys _securityKeys;
        public AppSettingsGetApiKeyService(IOptions<SecurityKeys> options)
        {
            _securityKeys = options.Value;

            _apiKey = _securityKeys.ApplicationKeys
                .Select(x => new ApiKey(x.App, x.Key, x.Roles))
                .ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKey.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}
