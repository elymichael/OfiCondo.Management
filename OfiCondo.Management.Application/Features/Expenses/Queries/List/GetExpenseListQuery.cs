namespace OfiCondo.Management.Application.Features.Expenses.Queries.List
{
    using MediatR;
    using System.Collections.Generic;
    public class GetExpenseListQuery : IRequest<List<ExpenseListVm>>
    {
    }
}
