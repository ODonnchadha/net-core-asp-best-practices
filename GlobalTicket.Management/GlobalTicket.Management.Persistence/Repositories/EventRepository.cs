namespace GlobalTicket.Management.Persistence.Repositories
{
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GlobalTicketDbContext context) : base(context) { }
        public Task<bool> IsEventNameAndDateUnique(string name, DateTime dt)
        {
            var matches = context.Events.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(dt.Date));
            return Task.FromResult(matches);
        }
    }
}
