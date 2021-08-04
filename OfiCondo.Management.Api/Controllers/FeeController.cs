namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Banks.Queries.Detail;
    using OfiCondo.Management.Application.Features.Fees.Commands.Create;
    using OfiCondo.Management.Application.Features.Fees.Commands.Delete;
    using OfiCondo.Management.Application.Features.Fees.Commands.Update;
    using OfiCondo.Management.Application.Features.Fees.Queries.Detail;
    using OfiCondo.Management.Application.Features.Fees.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class FeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllFees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FeeListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetFeeListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetFeeById")]
        public async Task<ActionResult<FeeDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetFeeDetailQuery() { FeeId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddFee")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateFeeCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateFee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateFeeCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteFee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteFeeCommand() { FeeId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
