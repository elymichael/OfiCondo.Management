namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    public class OnlyUserRequirement : IAuthorizationRequirement
    {
    }
    public class OnlyUserAuthorizationHandler : AuthorizationHandler<OnlyUserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyUserRequirement requirement)
        {
            if (context.User.IsInRole(Roles.User))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
