namespace OfiCondo.Management.Application.Contracts.Persistence
{
    using OfiCondo.Management.Domain.Entities;
    using System;
    using System.Threading.Tasks;
    public interface IPaymentMethodRepository : IAsyncRepository<PaymentMethod>
    {
        Task<PaymentMethod> GetByIntIdAsync(int id);
    }
}
