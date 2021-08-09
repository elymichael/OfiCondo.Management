namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Units.Commands.Create;
    using OfiCondo.Management.Application.Features.Units.Commands.Delete;
    using OfiCondo.Management.Application.Features.Units.Commands.Update;
    using OfiCondo.Management.Application.Features.Units.Queries.Detail;
    using OfiCondo.Management.Application.Features.Units.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllUnit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UnitListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetUnitListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetUnitById")]
        public async Task<ActionResult<UnitDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetUnitDetailQuery() { UnitId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddUnit")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateUnitCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateUnit")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateUnitCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUnit")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteUnitCommand() { UnitId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
