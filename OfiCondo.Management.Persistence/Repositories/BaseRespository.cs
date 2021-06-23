namespace OfiCondo.Management.Persistence.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using OfiCondo.Management.Application.Contracts.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BaseRespository<T> : IAsyncRepository<T> where T : class
    {
        public readonly OfiCondoDbContext _dbContext;

        public BaseRespository(OfiCondoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
