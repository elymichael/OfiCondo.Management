namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Minutes.Commands.Create;
    using OfiCondo.Management.Application.Features.Minutes.Commands.Delete;
    using OfiCondo.Management.Application.Features.Minutes.Commands.Update;
    using OfiCondo.Management.Application.Features.Minutes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Minutes.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class MinutesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MinutesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllMinutes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MinuteListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetMinuteListQuery());
            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetMinuteById")]
        public async Task<ActionResult<MinuteDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetMinuteDetailQuery() { MinuteId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
        [HttpPost(Name = "AddMinute")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateMinuteCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateMinute")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateMinuteCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteMinute")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteItemCommand = new DeleteMinuteCommand() { MinuteId = id };
            await _mediator.Send(deleteItemCommand);
            return NoContent();
        }
    }
}
