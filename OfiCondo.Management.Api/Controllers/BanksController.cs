namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Banks.Commands.Create;
    using OfiCondo.Management.Application.Features.Banks.Commands.Delete;
    using OfiCondo.Management.Application.Features.Banks.Commands.Update;
    using OfiCondo.Management.Application.Features.Banks.Queries.Detail;
    using OfiCondo.Management.Application.Features.Banks.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BanksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllBanks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BankListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetBankListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetBankById")]
        public async Task<ActionResult<BankDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetBankDetailQuery() { BankId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddBank")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateBankCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateBank")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateBankCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteBank")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteBankCommand() { BankId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
