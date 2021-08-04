namespace OfiCondo.Management.Application.Features.Incomes.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteIncomeCommand: IRequest
    {
        public Guid IncomeId { get; set; }
    }
}
