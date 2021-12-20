using MediatR;
using System.Collections.Generic;

namespace GlobalTicket.Management.Application.Features.Events.Queries
{
    public class GetEventListQuery : IRequest<List<EventListViewModel>> { }
}
