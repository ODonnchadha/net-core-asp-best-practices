namespace GlobalTicket.Management.Application.Features.Categories.Queries
{
    using MediatR;
    using System.Collections.Generic;

    public class GetCategoryListWithEventsQuery : IRequest<List<CategoryEventListViewModel>> 
    { 
        public bool IncludeHistory { get; set; }
    }
}
