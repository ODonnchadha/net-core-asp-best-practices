namespace GlobalTicket.Management.Application.Features.Events.Queries
{
    using MediatR;
    using System;
    public class GetEventDetailQuery : IRequest<EventDetailViewModel>
    {
        /// <summary>
        /// Obtain which event detail?
        /// </summary>
        public Guid Id { get; set; }
    }
}
