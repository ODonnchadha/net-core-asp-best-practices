namespace GlobalTicket.Management.Application.Features.Events.Commands
{
    using AutoMapper;
    using GlobalTicket.Management.Application.Contracts.Persistence;
    using GlobalTicket.Management.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IAsyncRepository<Event> repository;
        private readonly IMapper mapper;

        public DeleteEventCommandHandler(IAsyncRepository<Event> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.EventId);

            await repository.DeleteAsync(entity);

            return Unit.Value;
        }
    }
}
