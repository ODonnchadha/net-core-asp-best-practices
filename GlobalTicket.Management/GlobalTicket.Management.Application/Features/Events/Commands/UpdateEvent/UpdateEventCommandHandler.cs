namespace GlobalTicket.Management.Application.Features.Events.Commands.UpdateEvent
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> repository;
        private readonly IMapper mapper;

        public UpdateEventCommandHandler(IAsyncRepository<Event> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.EventId);

            mapper.Map(request, entity, typeof(UpdateEventCommand), typeof(Event));

            await repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
