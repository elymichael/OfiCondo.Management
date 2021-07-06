namespace OfiCondo.Management.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OfiCondo.Management.Application.Features.Categories.Commands.Create;
    using OfiCondo.Management.Application.Features.Categories.Commands.Delete;
    using OfiCondo.Management.Application.Features.Categories.Commands.Update;
    using OfiCondo.Management.Application.Features.Categories.Queries.Detail;
    using OfiCondo.Management.Application.Features.Categories.Queries.List;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }


        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDetailVm>> GetItemById(Guid id)
        {
            var getEventDetailQuery = new GetCategoryDetailQuery() { CategoryId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<ActionResult<Guid>>> Create([FromBody] CreateCategoryCommand createItemCommand)
        {
            var response = await _mediator.Send(createItemCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateCategoryCommand updateItemCommand)
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
            var deleteItemCommand = new DeleteCategoryCommand() { CategoryId = id };
            await _mediator.Send(deleteItemCommand);
            return NoContent();
        }
    }
}
