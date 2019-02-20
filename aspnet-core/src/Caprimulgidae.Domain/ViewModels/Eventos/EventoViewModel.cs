namespace Caprimulgidae.Domain.ViewModels.Eventos
{
    public sealed class EventoViewModel
    {
        private EventoViewModel() { }

        public string Token { get; private set; }
        public string Padrao { get; private set; }
        public decimal ProbabilidadeAcontecer { get; private set; }
        public decimal ProbabilidadeNaoAcontecer { get; private set; }
    }
}
