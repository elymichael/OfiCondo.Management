namespace OfiCondo.Management.Persistence.Repositories
{
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    public class IncomeRepository : BaseRespository<Income>, IIncomeRepository
    {
        public IncomeRepository(OfiCondoDbContext dbContext) : base(dbContext)
        {

        }
    }
}
