namespace GlobalTicket.Management.Application.Features.Categories.Queries
{
    using MediatR;
    using System.Collections.Generic;
    public class GetCategoryListQuery : IRequest<List<CategoryListViewModel>>
    {
    }
}
