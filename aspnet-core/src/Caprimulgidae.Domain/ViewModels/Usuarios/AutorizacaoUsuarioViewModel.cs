using Antilopes.ViewModels;

namespace Caprimulgidae.Domain.ViewModels.Usuarios
{
    public sealed class AutorizacaoUsuarioViewModel : ViewModel<AutorizacaoUsuarioViewModel>
    {
        private AutorizacaoUsuarioViewModel() { }

        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public string NomeCompleto => PrimeiroNome + " " + SegundoNome;
    }
}
