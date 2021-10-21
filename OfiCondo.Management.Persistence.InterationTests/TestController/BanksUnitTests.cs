namespace OfiCondo.Management.Persistence.InterationTests
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Newtonsoft.Json;
    using OfiCondo.Management.Api;
    using OfiCondo.Management.Api.Controllers;
    using OfiCondo.Management.Application.Features.Banks.Queries.Detail;
    using OfiCondo.Management.Application.Features.Banks.Queries.List;
    using OfiCondo.Management.Persistence.InterationTests.Base;
    using OfiCondo.Management.Persistence.InterationTests.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    public class BanksUnitTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly string controllerName = "Banks";
        private readonly CustomWebApplicationFactory<Startup> _factory;

        private readonly Mock<IMediator> _mediator;
        public BanksUnitTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task ReturnSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync($"/api/{controllerName}/all");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<BankListVm>>(responseString);

            Assert.IsType<List<BankListVm>>(result);
            Assert.NotEmpty(result);
        }
        [Fact]
        public async Task ReturnSuccessResultByID()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync($"/api/{controllerName}/{ConstantKeyValue.BankID}");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<BankDetailVm>(responseString);

            Assert.IsType<BankDetailVm>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultInsert()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new BanksController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Create(new Application.Features.Banks.Commands.Create.CreateBankCommand
            {
                AccountId = Guid.NewGuid(),
                AccountNumber = "7845752244-1",
                Description = "Cuenta de Ahorro Edificio Banco La Fe",
                Name = "Cuenta La Fe"

            });

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReturnSuccessResultUpdate()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new BanksController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Update(new Application.Features.Banks.Commands.Update.UpdateBankCommand
            {
                AccountId = Guid.NewGuid(),
                AccountNumber = "7845752244-1",
                Description = "Cuenta de Ahorro Edificio Banco La Fe",
                Name = "Cuenta La Fe",
                BankId = Guid.NewGuid()

            });

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ReturnSuccessResultDeleteMoq()
        {
            _mediator.Setup(m => m.Send(It.IsAny<object>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult((Object)Guid.NewGuid()));

            var controller = new BanksController(_mediator.Object)
            {
                ControllerContext = HttpContextTestHelper.GetContext()
            };

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsType<ActionResult<Guid>>(result);
        }
    }
}
