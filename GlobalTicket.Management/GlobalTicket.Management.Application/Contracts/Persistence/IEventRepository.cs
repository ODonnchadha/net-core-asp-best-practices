namespace GlobalTicket.Management.Application.Contracts.Persistence
{
    using GlobalTicket.Management.Domain.Entities;
    public interface IEventRepository : IAsyncRepository<Event>
    {
    }
}
