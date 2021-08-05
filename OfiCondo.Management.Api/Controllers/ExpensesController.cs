namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Expenses.Commands.Create;
    using OfiCondo.Management.Application.Features.Expenses.Commands.Delete;
    using OfiCondo.Management.Application.Features.Expenses.Commands.Update;
    using OfiCondo.Management.Application.Features.Expenses.Queries.Detail;
    using OfiCondo.Management.Application.Features.Expenses.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllExpenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ExpenseListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetExpenseListQuery());
            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetExpenseById")]
        public async Task<ActionResult<ExpenseDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetExpenseDetailQuery() { ExpenseId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
        [HttpPost(Name = "AddExpense")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateExpenseCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateExpense")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateExpenseCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteExpense")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var deleteItemCommand = new DeleteExpenseCommand() { ExpenseId = id };
            await _mediator.Send(deleteItemCommand);
            return NoContent();
        }
    }
}
