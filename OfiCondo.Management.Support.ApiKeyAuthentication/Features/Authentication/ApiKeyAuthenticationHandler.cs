namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authentication
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Constants;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Contracts.Authentication;
    using OfiCondo.Management.Support.ApiKeyAuthentication.Features.ErrorDetails;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Threading.Tasks;
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions>
    {

        private readonly IGetApiKeyService _getApiKeyQuery;
        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<ApiKeyAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IGetApiKeyService getApiKeyQuery) : base(options, logger, encoder, clock)
        {
            _getApiKeyQuery = getApiKeyQuery ?? throw new ArgumentNullException(nameof(getApiKeyQuery));
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(ApiKeyConstants.HeaderName, out var apiKeyHeaderValues))
            {
                return AuthenticateResult.NoResult();
            }

            var providedApiKey = apiKeyHeaderValues.FirstOrDefault();

            if (apiKeyHeaderValues.Count == 0 || string.IsNullOrWhiteSpace(providedApiKey))
            {
                return AuthenticateResult.NoResult();
            }

            var existingApiKey = await _getApiKeyQuery.Execute(providedApiKey);

            if (existingApiKey != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, existingApiKey.App)
                };

                claims.AddRange(existingApiKey.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var identity = new ClaimsIdentity(claims, Options.AuthenticationType);
                var identities = new List<ClaimsIdentity> { identity };
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, Options.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.NoResult();
        }
        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            await HandlerProblemAsync(401, new UnauthorizedDetails());
        }

        protected override async Task HandleForbiddenAsync(AuthenticationProperties properties)
        {
            await HandlerProblemAsync(403, new ForbiddenDetails());
        }

        private async Task HandlerProblemAsync(int statusCode, ProblemDetails errorDetails)
        {
            Response.StatusCode = statusCode;
            Response.ContentType = ApiKeyConstants.ProblemDetailsContentType;

            await Response.WriteAsync(
                JsonSerializer.Serialize(
                    errorDetails,
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, IgnoreNullValues = true }
                    )
                );
        }
    }
}
