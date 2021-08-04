namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Incomes.Commands.Create;
    using OfiCondo.Management.Application.Features.Incomes.Commands.Delete;
    using OfiCondo.Management.Application.Features.Incomes.Commands.Update;
    using OfiCondo.Management.Application.Features.Incomes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Incomes.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncomesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllIncomes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<IncomeListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetIncomeListQuery());
            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetIncomeById")]
        public async Task<ActionResult<IncomeDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetIncomeDetailQuery() { IncomeId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
        [HttpPost(Name = "AddIncome")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateIncomeCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateIncomeCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteItemCommand = new DeleteIncomeCommand() { IncomeId = id };
            await _mediator.Send(deleteItemCommand);
            return NoContent();
        }
    }
}
