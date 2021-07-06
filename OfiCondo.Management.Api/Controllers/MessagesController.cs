namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Messages.Commands.Create;
    using OfiCondo.Management.Application.Features.Messages.Commands.Delete;
    using OfiCondo.Management.Application.Features.Messages.Commands.Update;
    using OfiCondo.Management.Application.Features.Messages.Queries.Detail;
    using OfiCondo.Management.Application.Features.Messages.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllMessage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MessageListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetMessageListQuery());
            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetMessageById")]
        public async Task<ActionResult<MessageDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetMessageDetailQuery() { MessageId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
        [HttpPost(Name = "AddMessage")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateMessageCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateMessage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateMessageCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteMessage")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteItemCommand = new DeleteMessageCommand() { MessageId = id };
            await _mediator.Send(deleteItemCommand);
            return NoContent();
        }
    }
}
