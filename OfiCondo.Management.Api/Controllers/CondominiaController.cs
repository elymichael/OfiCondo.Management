namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Condominia.Commands.Create;
    using OfiCondo.Management.Application.Features.Condominia.Commands.Delete;
    using OfiCondo.Management.Application.Features.Condominia.Commands.Update;
    using OfiCondo.Management.Application.Features.Condominia.Queries.Detail;
    using OfiCondo.Management.Application.Features.Condominia.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CondominiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CondominiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCondominium")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CondominiumListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetCondominiumListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetCondominiumById")]
        public async Task<ActionResult<CondominiumDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetCondominiumDetailQuery() { CondominiumId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }

        [HttpPost(Name = "AddCondominium")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateCondominiumCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCondominium")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCondominiumCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCondominium")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteEventCommand = new DeleteCondominiumCommand() { CondominiumId = id };
            await _mediator.Send(deleteEventCommand);
            return NoContent();
        }
    }
}
