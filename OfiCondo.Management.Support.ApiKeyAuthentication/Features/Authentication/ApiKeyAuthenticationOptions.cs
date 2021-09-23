namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authentication
{
    using Microsoft.AspNetCore.Authentication;
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "API Key";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;
    }
}
