namespace OfiCondo.Management.Support.ApiKeyAuthentication.Contracts.Authentication
{
    using OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authentication;
    using System.Threading.Tasks;
    public interface IGetApiKeyService
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
