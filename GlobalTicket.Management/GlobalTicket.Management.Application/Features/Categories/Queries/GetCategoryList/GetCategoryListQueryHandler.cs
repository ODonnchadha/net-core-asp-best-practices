namespace GlobalTicket.Management.Application.Features.Categories.Queries
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListViewModel>>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public GetCategoryListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryListViewModel>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = (await categoryRepository.ListAllAsync()).OrderBy(c => c.Name);
            var viewModels = mapper.Map<List<CategoryListViewModel>>(categories);

            return viewModels;
        }
    }
}
