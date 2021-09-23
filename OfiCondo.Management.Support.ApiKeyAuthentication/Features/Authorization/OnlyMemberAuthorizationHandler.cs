namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.Authorization
{
    using Microsoft.AspNetCore.Authorization;
    using System.Threading.Tasks;
    public class OnlyMemberRequirement : IAuthorizationRequirement
    {
    }
    public class OnlyMemberAuthorizationHandler : AuthorizationHandler<OnlyMemberRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OnlyMemberRequirement requirement)
        {
            if (context.User.IsInRole(Roles.Member))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
