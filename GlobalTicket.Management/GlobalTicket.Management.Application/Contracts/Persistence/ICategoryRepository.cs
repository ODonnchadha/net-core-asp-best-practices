namespace GlobalTicket.Management.Application.Contracts.Persistence
{
    using GlobalTicket.Management.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
