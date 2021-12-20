namespace GlobalTicket.Management.Application.Features.Events.Commands
{
    using FluentValidation;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository repository;
        public CreateEventCommandValidator(IEventRepository repository)
        {
            this.repository = repository;

            RuleFor(cmd => cmd.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(cmd => cmd.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(cmd => cmd)
                .MustAsync(EventNameAndDateUnique).WithMessage("An event with the same name and date already exists.");
            RuleFor(cmd => cmd.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand c, CancellationToken token) => !(await repository.IsEventNameAndDateUnique(c.Name, c.Date));
    }
}
