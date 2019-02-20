using Antilopes.Domain.Core.Commands;

namespace Caprimulgidae.Domain.Commands.Usuarios
{
    public abstract class UsuarioCommand : Command
    {
        public string PrimeiroNome { get; protected set; }
        public string SegundoNome { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
    }
}
