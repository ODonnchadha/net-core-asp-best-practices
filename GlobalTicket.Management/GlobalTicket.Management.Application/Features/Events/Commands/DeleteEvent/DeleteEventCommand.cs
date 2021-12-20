namespace GlobalTicket.Management.Application.Features.Events.Commands
{
    using MediatR;
    using System;

    public class DeleteEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}
