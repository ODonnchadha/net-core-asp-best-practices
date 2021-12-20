namespace GlobalTicket.Management.Persistence.Repositories
{
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly GlobalTicketDbContext context;
        public BaseRepository(GlobalTicketDbContext context) => this.context = context;
        public async Task<T> AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id) => await context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync() => await context.Set<T>().ToListAsync();

        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
