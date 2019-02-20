using Antilopes.ViewModels;

namespace Caprimulgidae.Domain.ViewModels.Estimativas
{
    public sealed class EstimativaPorBayesViewModel : ViewModel<EstimativaPorBayesViewModel>
    {
        private EstimativaPorBayesViewModel(
            decimal priory,
            decimal posteriory,
            decimal probabilidade)
        {
            Priory = priory;
            Posteriory = posteriory;
            Probabilidade = probabilidade;
        }

        public decimal Priory { get; private set; }
        public decimal Posteriory { get; private set; }
        public decimal Probabilidade { get; private set; }

        internal static EstimativaPorBayesViewModel Criar(
             decimal priory,
             decimal posteriory,
             decimal probabilidade) =>
            new EstimativaPorBayesViewModel(
                priory,
                posteriory,
                probabilidade);
    }
}
