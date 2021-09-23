namespace OfiCondo.Management.Support.ApiKeyAuthentication.Features.ErrorDetails
{
    using Microsoft.AspNetCore.Mvc;
    public class UnauthorizedDetails : ProblemDetails
    {
        public UnauthorizedDetails(string detail = null)
        {
            Title = "Unauthorized";
            Detail = detail;
            Status = 401;
            Type = "https://httpstatuses.com/401";
        }
    }
}
