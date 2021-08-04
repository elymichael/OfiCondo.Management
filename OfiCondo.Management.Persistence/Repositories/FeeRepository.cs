namespace OfiCondo.Management.Persistence.Repositories
{
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Linq;
    using System.Threading.Tasks;
    public class FeeRepository : BaseRespository<Fee>, IFeeRepository
    {
        public FeeRepository(OfiCondoDbContext dbContext) : base(dbContext)
        {

        }
        public Task<bool> IsUnique(string name)
        {
            var matches = _dbContext.Banks.Any(e => e.Name.Equals(name));
            return Task.FromResult(matches);
        }
    }
}
