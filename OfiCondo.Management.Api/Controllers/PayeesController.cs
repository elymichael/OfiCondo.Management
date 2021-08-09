namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Payees.Commands.Create;
    using OfiCondo.Management.Application.Features.Payees.Commands.Delete;
    using OfiCondo.Management.Application.Features.Payees.Commands.Update;
    using OfiCondo.Management.Application.Features.Payees.Queries.Detail;
    using OfiCondo.Management.Application.Features.Payees.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PayeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PayeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllPayees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PayeeListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetPayeeListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPayeeById")]
        public async Task<ActionResult<PayeeDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetPayeeDetailQuery() { PayeeId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddPayee")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreatePayeeCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdatePayee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdatePayeeCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePayee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteEventCommand = new DeletePayeeCommand() { PayeeId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
