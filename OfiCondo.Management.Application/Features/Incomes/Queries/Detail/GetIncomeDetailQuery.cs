namespace OfiCondo.Management.Application.Features.Incomes.Queries.Detail
{
    using MediatR;
    using System;

    public class GetIncomeDetailQuery : IRequest<IncomeDetailVm>
    {
        public Guid IncomeId { get; set; }
    }
}
