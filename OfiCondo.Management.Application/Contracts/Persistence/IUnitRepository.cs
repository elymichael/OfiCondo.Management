namespace OfiCondo.Management.Application.Contracts.Persistence
{
    using OfiCondo.Management.Domain.Entities;
    using System.Threading.Tasks;

    public interface IUnitRepository : IAsyncRepository<Unit>
    {
        Task<bool> IsUnique(string name);
    }
}
