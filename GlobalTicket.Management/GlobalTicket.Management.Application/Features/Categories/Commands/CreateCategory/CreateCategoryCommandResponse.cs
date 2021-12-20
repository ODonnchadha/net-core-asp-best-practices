namespace GlobalTicket.Management.Application.Features.Categories.Commands
{
    using GlobalTicket.Management.Application.Responses;

    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base() { }
        public CreateCategoryDto Category { get; set; }
    }
}
