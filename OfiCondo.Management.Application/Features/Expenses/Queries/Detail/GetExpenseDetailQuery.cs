namespace OfiCondo.Management.Application.Features.Expenses.Queries.Detail
{
    using MediatR;
    using System;

    public class GetExpenseDetailQuery : IRequest<ExpenseDetailVm>
    {
        public Guid ExpenseId { get; set; }
    }
}
