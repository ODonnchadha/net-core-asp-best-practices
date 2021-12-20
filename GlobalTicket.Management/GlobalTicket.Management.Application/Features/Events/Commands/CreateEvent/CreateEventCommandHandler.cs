namespace GlobalTicket.Management.Application.Features.Events.Commands
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Infrastructure;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Application.Models.Mail;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEmailService service;
        private readonly IEventRepository repository;
        private readonly IMapper mapper;

        public CreateEventCommandHandler(IEmailService service, IEventRepository repository, IMapper mapper)
        {
            this.service = service;
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(repository);
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Count > 0) throw new Exceptions.ValidationException(result);

            var @event = mapper.Map<Event>(request);

            @event = await repository.AddAsync(@event);

            var email = new Email { Body = "", Subject = "", To = "" };

            try
            {
                await service.Send(email);
            }
            catch { }

            return @event.EventId;
        }
    }
}
