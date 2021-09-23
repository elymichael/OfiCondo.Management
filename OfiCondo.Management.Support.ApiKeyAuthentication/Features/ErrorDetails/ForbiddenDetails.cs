namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.ErrorDetails
{
    using Microsoft.AspNetCore.Mvc;
    public class ForbiddenDetails : ProblemDetails
    {
        public ForbiddenDetails(string detail = null)
        {
            Title = "Forbidden";
            Detail = detail;
            Status = 403;
            Type = "https://httpstatuses.com/403";
        }
    }
}
