namespace GlobalTicket.Management.Application.Features.Categories.Commands
{
    using FluentValidation;

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
        }
    }
}
