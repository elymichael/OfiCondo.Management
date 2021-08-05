namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Api.Attributes;
    using OfiCondo.Management.Application.Contracts.Authentication;
    using OfiCondo.Management.Application.Features.Accounts.Commands.Create;
    using OfiCondo.Management.Application.Models.Authentication;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    //[ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMediator _mediator;
        public AccountController(
            IAuthenticationService authenticationService, 
            IMediator mediator)
        {
            _authenticationService = authenticationService;
            _mediator = mediator;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            RegistrationResponse registrationResponse = await _authenticationService.RegisterAsync(request);
            
            var account = new CreateAccountCommand
            {
                Name = $"{request.FirstName} {request.LastName}",
                Phone = request.Phone,
                Email = request.Email,
                AccountId = Guid.Parse(registrationResponse.UserId)
            };
            var response = await _mediator.Send(account);

            return Ok(registrationResponse);
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<AuthorizedUsers>>> GetAllAccounts()
        {
            return await Task.FromResult(_authenticationService.GetAllAcounts());
        }
    }
}
