namespace GlobalTicket.Management.Application.Features.Events.Queries
{
    using MediatR;
    using System;

    public class GetEventDetailQuery : IRequest<EventDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}
