namespace OfiCondo.Management.Application.Contracts.Persistence
{
    using OfiCondo.Management.Domain.Entities;
    public interface IExpenseRepository: IAsyncRepository<Expense>
    {
    }
}
