using MediatR;
using System.Collections.Generic;

namespace GlobalTicket.Management.Application.Features.Events.Queries
{
    /// <summary>
    /// Message: IRequest<List<EventListViewModel>>
    /// </summary>
    public class GetEventListQuery : IRequest<List<EventListViewModel>>
    {
    }
}
