using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Commands;
using Antilopes.Domain.Core.Notifications;
using Antilopes.Domain.Core.UoW;
using Caprimulgidae.Domain.Commands.Estimativas;
using Caprimulgidae.Domain.Interfaces.Estimativas;
using Caprimulgidae.Domain.Interfaces.Eventos;
using Caprimulgidae.Domain.Models.Estimativas;
using Caprimulgidae.Domain.ViewModels.Estimativas;
using Caprimulgidae.Domain.ViewModels.Eventos;
using MediatR;
using Optional;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Caprimulgidae.Domain.CommandHandlers
{
    public sealed class EstimativaCommandHandler :
        CommandHandler,
        IRequestHandler<EstimativaBayesPorTextoCommand, Option<EstimativaPorBayesViewModel>>
    {
        private readonly IEventoReadOnlyRepository eventoReadOnlyRepository;
        private readonly IEstimativaDomainRepository estimativaDomainRepository;

        public EstimativaCommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IEventoReadOnlyRepository eventoReadOnlyRepository,
            IEstimativaDomainRepository estimativaDomainRepository)
            : base(uow, bus, notifications)
        {
            this.estimativaDomainRepository = estimativaDomainRepository;
            this.eventoReadOnlyRepository = eventoReadOnlyRepository;
        }

        public async Task<Option<EstimativaPorBayesViewModel>> Handle(
            EstimativaBayesPorTextoCommand request,
            CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Option.None<EstimativaPorBayesViewModel>();
            var eventos = (await eventoReadOnlyRepository.ObterEventosPorTexto(request.Texto))
                .ValueOr(Enumerable.Empty<EventoViewModel>());

            var estimativas = eventos.Select(x => Task.Factory.StartNew(() =>
                Estimativa.CriarEstimativaPorTeoremaBayes(
                    x.ProbabilidadeAcontecer,
                    x.ProbabilidadeNaoAcontecer)));

            await Task.WhenAll(estimativas);

            var tarefaParaObterMediaPriory = Task.Run(() => estimativas
                .Select(x => x.Result.Priory).Average());
            var tarefaParaObterMediaPosteriory = Task.Run(() => estimativas
                .Select(x => x.Result.Posteriory).Average());
            var tarefaParaObterMediaProbabilidade = Task.Run(() => estimativas
                .Select(x => x.Result.Probabilidade).Average());

            await Task.WhenAll(
                tarefaParaObterMediaPriory,
                tarefaParaObterMediaPosteriory,
                tarefaParaObterMediaProbabilidade);

            var estimativa = Estimativa.CriarEstimativaPorTeoremaBayes(
                            tarefaParaObterMediaPriory.Result,
                            tarefaParaObterMediaPosteriory.Result);

            await estimativaDomainRepository.Add(estimativa);
            if (!await Commit())
                return Option.None<EstimativaPorBayesViewModel>();

            return Option.Some(
                EstimativaPorBayesViewModel.Criar(
                    tarefaParaObterMediaPriory.Result,
                    tarefaParaObterMediaPosteriory.Result,
                    tarefaParaObterMediaProbabilidade.Result));
        }

        public override void Dispose()
        {
            eventoReadOnlyRepository.Dispose();
            estimativaDomainRepository.Dispose();
        }
    }
}
