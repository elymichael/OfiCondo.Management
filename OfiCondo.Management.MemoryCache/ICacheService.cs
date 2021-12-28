namespace OfiCondo.Management.MemoryCache
{
    using Microsoft.Extensions.Caching.Memory;
    using System.Threading.Tasks;
    public interface ICacheService<T>
    {
        Task<T> Get(string key);

        void Set(string key, T entry, MemoryCacheEntryOptions options = null);
        void Remove(string key);
    }
}
