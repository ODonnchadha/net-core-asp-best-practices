namespace GlobalTicket.Management.Application.Profiles
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Features.Categories.Queries;
    using GlobalTicket.Management.Application.Features.Events.Queries;
    using GlobalTicket.Management.Domain.Entities;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListViewModel>().ReverseMap();
            CreateMap<Event, EventDetailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Category, CategoryListViewModel>().ReverseMap();
            CreateMap<Category, CategoryEventListViewModel>().ReverseMap();
        }
    }
}
