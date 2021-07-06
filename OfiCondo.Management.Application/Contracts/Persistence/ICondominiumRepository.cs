namespace OfiCondo.Management.Application.Contracts.Persistence
{
    using OfiCondo.Management.Domain.Entities;
    using System.Threading.Tasks;

    public interface ICondominiumRepository : IAsyncRepository<Condominium>
    {
        Task<bool> IsUnique(string name);
    }
}
