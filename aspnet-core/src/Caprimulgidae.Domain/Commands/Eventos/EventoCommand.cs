using Antilopes.Domain.Core.Commands;

namespace Caprimulgidae.Domain.Commands.Eventos
{
    public abstract class EventoCommand : Command
    {
        public string Token { get; protected set; }
        public string Padrao { get; protected set; }
        public decimal ProbabilidadeAcontecer { get; protected set; }
    }
}
