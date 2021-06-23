namespace OfiCondo.Management.Api.Services
{
    using Microsoft.AspNetCore.Http;
    using OfiCondo.Management.Application.Contracts;
    using System.Security.Claims;

    public class LoggedInUserService: ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string UserId { get; set; }
    }
}
