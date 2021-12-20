namespace GlobalTicket.Management.Application.Features.Categories.Commands
{
    using MediatR;

    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
