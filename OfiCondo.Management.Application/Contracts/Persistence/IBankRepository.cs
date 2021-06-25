namespace OfiCondo.Management.Application.Contracts.Persistence
{
    using OfiCondo.Management.Domain.Entities;
    using System.Threading.Tasks;

    public interface IBankRepository: IAsyncRepository<Bank>
    {
        Task<bool> IsUnique(string name);
    }
}
