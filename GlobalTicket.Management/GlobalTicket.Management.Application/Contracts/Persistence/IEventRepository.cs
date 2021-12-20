namespace GlobalTicket.Management.Application.Contracts.Persistence
{
    using GlobalTicket.Management.Domain.Entities;
    using System;
    using System.Threading.Tasks;

    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime dt);
    }
}
