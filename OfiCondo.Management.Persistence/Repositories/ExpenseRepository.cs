namespace OfiCondo.Management.Persistence.Repositories
{
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    public class ExpenseRepository : BaseRespository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(OfiCondoDbContext dbContext) : base(dbContext)
        {

        }
    }
}
