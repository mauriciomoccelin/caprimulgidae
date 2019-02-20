using Antilopes.Domain.Core.Bus;
using Caprimulgidae.Application.Interfaces;
using Caprimulgidae.Domain.Commands.Estimativas;
using Caprimulgidae.Domain.ViewModels.Estimativas;
using Optional;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Application.Services
{
    public class EstimativaAppService : IEstimativaAppService
    {
        private readonly IMediatorHandler bus;

        public EstimativaAppService(
            IMediatorHandler bus)
        {
            this.bus = bus;
        }

        public async Task<EstimativaPorBayesViewModel> EstimativaPorBayesUsandoTexto(string texto) =>
            (await bus.SendCommand<EstimativaBayesPorTextoCommand, Option<EstimativaPorBayesViewModel>>(
                EstimativaBayesPorTextoCommand.Criar(texto))
            ).Match(
                some: estimativa => estimativa,
                none: EstimativaPorBayesViewModel.Empty);

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
