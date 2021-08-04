namespace OfiCondo.Management.Application.Features.Incomes.Queries.List
{
    using MediatR;
    using System.Collections.Generic;
    public class GetIncomeListQuery : IRequest<List<IncomeListVm>>
    {
    }
}
