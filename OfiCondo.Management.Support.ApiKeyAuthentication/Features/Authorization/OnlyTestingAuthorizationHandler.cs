namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    public class OnlyTestingRequirement : IAuthorizationRequirement
    {
    }

    public class OnlyTestingAuthorizationHandler : AuthorizationHandler<OnlyTestingRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyTestingRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Testing))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
