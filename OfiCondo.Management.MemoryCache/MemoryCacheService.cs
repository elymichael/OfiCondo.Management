namespace OfiCondo.Management.MemoryCache
{
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Threading.Tasks;
    public class MemoryCacheService<T> : ICacheService<T>
    {
        protected readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public virtual Task<T> Get(string key)
        {
            T entry = default;
            _memoryCache.TryGetValue(key, out entry);
            return Task.FromResult(entry);
        }

        public void Remove(string key) => 
            _memoryCache.Remove(key);

        public void Set(string key, T entry, MemoryCacheEntryOptions options = null) => 
            _memoryCache.Set(key, entry, options ?? new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
    }
}
