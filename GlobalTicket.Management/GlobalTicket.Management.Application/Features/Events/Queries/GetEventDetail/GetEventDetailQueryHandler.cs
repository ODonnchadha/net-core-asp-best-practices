namespace GlobalTicket.Management.Application.Features.Events.Queries
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailViewModel>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IAsyncRepository<Event> eventRepository;
        private readonly IMapper mapper;

        public GetEventDetailQueryHandler(IAsyncRepository<Category> categoryRepository, IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        public async Task<EventDetailViewModel> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var @event = await eventRepository.GetByIdAsync(request.Id);
            var viewModel = mapper.Map<EventDetailViewModel>(@event);

            var category = await categoryRepository.GetByIdAsync(@event.CategoryId);

            viewModel.Category = mapper.Map<CategoryDto>(category);

            return viewModel;
        }
    }
}
