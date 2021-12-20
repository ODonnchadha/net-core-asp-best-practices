namespace GlobalTicket.Management.Application.Features.Events.Queries
{
    using System;

    public class EventListViewModel
    {
        public Guid EventId { get; set; }
        public string name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
