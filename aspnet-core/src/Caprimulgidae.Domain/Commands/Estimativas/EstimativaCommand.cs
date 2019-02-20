using Antilopes.Domain.Core.Commands;

namespace Caprimulgidae.Domain.Commands.Estimativas
{
    public abstract class EstimativaCommand : Command
    {
        public string Texto { get; protected set; }
    }
}
