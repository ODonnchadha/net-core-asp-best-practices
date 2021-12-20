namespace GlobalTicket.Management.Application.Features.Categories.Commands
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> repository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IAsyncRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCategoryCommandResponse { };

            var validator = new CreateCategoryCommandValidator { };
            var result = await validator.ValidateAsync(request);

            if (result.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                result.Errors.ForEach(e => response.ValidationErrors.Add(e.ErrorMessage));
            }

            if (response.Success)
            {
                var category = new Category { Name = request.Name };

                category = await repository.AddAsync(category);
                var viewModel = mapper.Map<CreateCategoryDto>(category);

                response.Category = viewModel;
            }

            return response;
        }
    }
}
