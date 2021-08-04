namespace OfiCondo.Management.Application.Contracts.Persistence
{
    using OfiCondo.Management.Domain.Entities;
    using System.Threading.Tasks;

    public interface IFeeRepository : IAsyncRepository<Fee>
    {
        Task<bool> IsUnique(string name);
    }
}
