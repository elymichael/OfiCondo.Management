namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Api.Attributes;
    using OfiCondo.Management.Api.Utility;
    using OfiCondo.Management.Application.Contracts.Authentication;
    using OfiCondo.Management.Application.Features.Accounts.Commands.Create;
    using OfiCondo.Management.Application.Features.Accounts.Commands.Delete;
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
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]        
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("Register")]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]        
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            RegistrationResponse registrationResponse = await _authenticationService.RegisterAsync(request);
            
            return Ok(registrationResponse);
        }

        [HttpGet("All")]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]        
        public async Task<ActionResult<List<AuthorizedUsers>>> GetAllAccounts()
        {
            return await Task.FromResult(_authenticationService.GetAllAcounts());
        }

        [HttpGet("{id}", Name = "GetAccountById")]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        public async Task<ActionResult<AuthorizedUsers>> GetAllAccounts(string id)
        {
            return await _authenticationService.GetAccountById(id);
        }

        [HttpPost("AssociateUserToPrincipalAccount")]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<object>> AssociateUserToPrincipalAccount(UserInfo model)
        {
            var request = await _authenticationService.GetAccountById(model.UserId.ToString());

            var account = new CreateAccountCommand
            {
                Name = $"{request.FirstName} {request.LastName}",
                Phone = model.Phone,
                Email = request.Email,
                AccountId = Guid.Parse(request.Id)
            };

            var response = await _mediator.Send(account);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteUserRelationtoAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteAccountCommand() { AccountId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
