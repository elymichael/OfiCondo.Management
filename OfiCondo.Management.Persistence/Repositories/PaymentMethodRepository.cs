namespace OfiCondo.Management.Persistence.Repositories
{
    using OfiCondo.Management.Application.Contracts.Persistence;
    using OfiCondo.Management.Domain.Entities;
    using System.Threading.Tasks;

    class PaymentMethodRepository : BaseRespository<PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(OfiCondoDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<PaymentMethod> GetByIntIdAsync(int id)
        {
            return await _dbContext.PaymentMethods.FindAsync(id);
        }
    }
}
