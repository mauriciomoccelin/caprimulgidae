using Caprimulgidae.Domain.ViewModels.Estimativas;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Application.Interfaces
{
    public interface IEstimativaAppService : IDisposable
    {
        Task<EstimativaPorBayesViewModel> EstimativaPorBayesUsandoTexto(string texto);
    }
}
