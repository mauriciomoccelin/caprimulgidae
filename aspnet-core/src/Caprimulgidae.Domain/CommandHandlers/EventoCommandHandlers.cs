using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Commands;
using Antilopes.Domain.Core.Notifications;
using Antilopes.Domain.Core.UoW;
using Caprimulgidae.Domain.Commands.Eventos;
using Caprimulgidae.Domain.Interfaces.Eventos;
using Caprimulgidae.Domain.Models.Eventos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Caprimulgidae.Domain.CommandHandlers
{
    public sealed class EventoCommandHandlers :
        CommandHandler,
        IRequestHandler<CadastrarEventoCommand>
    {
        private readonly IEventoDomainRepository eventoDomainRepository;

        public EventoCommandHandlers(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IEventoDomainRepository eventoDomainRepository)
            : base(uow, bus, notifications)
        {
            this.eventoDomainRepository = eventoDomainRepository;
        }

        public async Task<Unit> Handle(CadastrarEventoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return await Unit.Task;

            var evento = Evento.Criar(
                request.Token,
                request.Padrao,
                request.ProbabilidadeAcontecer);

            await eventoDomainRepository.Add(evento);
            await Commit();

            return await Unit.Task;
        }

        public override void Dispose()
        {
            eventoDomainRepository.Dispose();
        }
    }
}
