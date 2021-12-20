namespace GlobalTicket.Management.Application.Contracts.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
