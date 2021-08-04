namespace OfiCondo.Management.Application.Features.Expenses.Commands.Delete
{
    using MediatR;
    using System;
    public class DeleteExpenseCommand: IRequest
    {
        public Guid ExpenseId { get; set; }
    }
}
