using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfiCondo.Management.Application.Features.PaymentMethod.Queries.Detail;
using OfiCondo.Management.Application.Features.PaymentMethod.Queries.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfiCondo.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentMethodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllPaymentMethods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PaymentMethodListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetPaymentMethodListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetPaymentMethodById")]
        public async Task<ActionResult<PaymentMethodDetailVm>> GetItemById(int id)
        {
            var getEventDetailQuery = new GetPaymentMethodDetailQuery() { PaymentMethodId = id };
            return Ok(await _mediator.Send(getEventDetailQuery));
        }
    }
}
