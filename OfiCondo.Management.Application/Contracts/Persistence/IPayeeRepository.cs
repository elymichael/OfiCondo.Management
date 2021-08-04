namespace OfiCondo.Management.Application.Contracts.Persistence
{
    using OfiCondo.Management.Domain.Entities;
    using System.Threading.Tasks;

    public interface IPayeeRepository: IAsyncRepository<Payee>
    {
        Task<bool> IsUnique(string name);
    }
}
