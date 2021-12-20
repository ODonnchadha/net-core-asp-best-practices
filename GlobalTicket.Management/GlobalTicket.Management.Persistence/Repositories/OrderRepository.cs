namespace GlobalTicket.Management.Persistence.Repositories
{
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(GlobalTicketDbContext context) : base(context) { }
    }
}
