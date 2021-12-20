namespace GlobalTicket.Management.Persistence.Repositories
{
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    { 
        public CategoryRepository(GlobalTicketDbContext context) : base(context) { }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var categories = await context.Categories.Include(c => c.Events).ToListAsync();

            if (!includePassedEvents)
            {
                categories.ForEach(c => c.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }

            return categories;
        }
    }
}
