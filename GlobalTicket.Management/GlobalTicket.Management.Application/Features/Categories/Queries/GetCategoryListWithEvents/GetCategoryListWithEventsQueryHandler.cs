namespace GlobalTicket.Management.Application.Features.Categories.Queries
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetCategoryListWithEventsQueryHandler : IRequestHandler<GetCategoryListWithEventsQuery, List<CategoryEventListViewModel>>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        public GetCategoryListWithEventsQueryHandler(ICategoryRepository categoryRepository, IAsyncRepository<Event> eventRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        public async Task<List<CategoryEventListViewModel>> Handle(GetCategoryListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
            var viewModels = mapper.Map<List<CategoryEventListViewModel>>(categories);

            return viewModels;
        }
    }
}
