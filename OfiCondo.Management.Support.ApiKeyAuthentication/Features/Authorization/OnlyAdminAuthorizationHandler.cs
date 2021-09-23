namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    public class OnlyAdminRequirement : IAuthorizationRequirement
    {
    }
    public class OnlyAdminAuthorizationHandler : AuthorizationHandler<OnlyAdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyAdminRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Admin))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
