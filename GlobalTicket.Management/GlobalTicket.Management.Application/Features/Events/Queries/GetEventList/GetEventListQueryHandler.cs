namespace GlobalTicket.Management.Application.Features.Events.Queries
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventListViewModel>>
    {
        private readonly IAsyncRepository<Event> eventRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// GetEventListQueryHandler.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public GetEventListQueryHandler(IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// All events ordered by date. A list of entities.
        /// Return view models. Ensure MappingProfile exists.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<EventListViewModel>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var events = (await eventRepository.ListAllAsync()).OrderBy(e => e.Date);
            var viewModels = mapper.Map<List<EventListViewModel>>(events);

            return viewModels;
        }
    }
}
