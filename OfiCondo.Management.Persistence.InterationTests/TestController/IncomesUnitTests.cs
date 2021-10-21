﻿namespace OfiCondo.Management.Persistence.InterationTests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Api.Controllers;
    using OfiCondo.Management.Application.Features.Incomes.Queries.Detail;
    using OfiCondo.Management.Application.Features.Incomes.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using OfiCondo.Management.Persistence.InterationTests.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class IncomesUnitTests : BaseController
    {
        private readonly string controllerName = "Incomes";
        private readonly Mock<IMediator> _mediator;
        public IncomesUnitTests(CustomWebApplicationFactory<Startup> factory) : base(factory) 
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/all");

            var result = JsonConvert.DeserializeObject<List<IncomeListVm>>(response);

            Assert.IsType<List<IncomeListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            string response = await base.ExecGetEndPoint($"/api/{controllerName}/{ConstantKeyValue.IncomeID}");

            var result = JsonConvert.DeserializeObject<IncomeDetailVm>(response);

            Assert.IsType<IncomeDetailVm>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultInsert()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new IncomesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Create(new Application.Features.Incomes.Commands.Create.CreateIncomeCommand
            {                             
                Description = "Cuenta de Ahorro Edificio Banco La Fe",
                Amount = 10,
                AttachmentId = Guid.NewGuid(),
                CondominiumId = Guid.NewGuid(),                
                RecordDate = DateTime.Now,
                FeeId = Guid.NewGuid(),
                UnitId = Guid.NewGuid()

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new IncomesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Update(new Application.Features.Incomes.Commands.Update.UpdateIncomeCommand
            {
                FeeId = Guid.NewGuid(),
                UnitId = Guid.NewGuid(),
                Description = "Cuenta de Ahorro Edificio Banco La Fe",
                Amount = 10,
                AttachmentId = Guid.NewGuid(),
                CondominiumId = Guid.NewGuid(),                
                RecordDate = DateTime.Now,
                IncomeId = Guid.NewGuid()

            }); ;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultDeleteMoq()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new IncomesController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsType<ActionResult<Guid>>(result);
        }

        public async Task ReturnSuccessResultDelete()
        {
            Guid id = await base.ExecDeleteEndPoint<Guid>($"/api/{controllerName}/{ConstantKeyValue.IncomeID}");

            Assert.IsType<Guid>(id);
        }
    }
}
