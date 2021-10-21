namespace OfiCondo.Management.Persistence.InterationTests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Api.Controllers;
    using OfiCondo.Management.Application.Features.Expenses.Queries.Detail;
    using OfiCondo.Management.Application.Features.Expenses.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using OfiCondo.Management.Persistence.InterationTests.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class ExpensesUnitTests : BaseController
    {
        private readonly string controllerName = "Expenses";
        private readonly Mock<IMediator> _mediator;
        public ExpensesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<ExpenseListVm>>(response);

            Assert.IsType<List<ExpenseListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.ExpenseID}");

            var result = JsonConvert.DeserializeObject<ExpenseDetailVm>(response);

            Assert.IsType<ExpenseDetailVm>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultInsert()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new ExpensesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Create(new Application.Features.Expenses.Commands.Create.CreateExpenseCommand
            {
                PayeeId = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),                
                Description = "Cuenta de Ahorro Edificio Banco La Fe",
                Amount = 10,
                AttachmentId = Guid.NewGuid(),
                CondominiumId = Guid.NewGuid(),
                PaymentMethodId = 1,
                RecordDate = DateTime.Now

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new ExpensesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Update(new Application.Features.Expenses.Commands.Update.UpdateExpenseCommand
            {
                PayeeId = Guid.NewGuid(),
                CategoryId = Guid.NewGuid(),
                Description = "Cuenta de Ahorro Edificio Banco La Fe",
                Amount = 10,
                AttachmentId = Guid.NewGuid(),
                CondominiumId = Guid.NewGuid(),
                PaymentMethodId = 1,
                RecordDate = DateTime.Now,
                ExpenseId = Guid.NewGuid()

            }); ;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultDeleteMoq()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new ExpensesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsType<ActionResult<Guid>>(result);
        }

        public async Task ReturnSuccessResultDelete()
        {
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.ExpenseID}");

            Assert.IsType<Guid>(id);
        }
    }
}
