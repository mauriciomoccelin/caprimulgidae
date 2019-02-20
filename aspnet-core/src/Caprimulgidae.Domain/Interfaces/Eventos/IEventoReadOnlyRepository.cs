using Antilopes.Domain.Core.Repositorys;
using Caprimulgidae.Domain.ViewModels.Eventos;
using Optional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Caprimulgidae.Domain.Interfaces.Eventos
{
    public interface IEventoReadOnlyRepository : IReadOnlyRepository
    {
        Task<Option<IEnumerable<EventoViewModel>>> ObterEventosPorTexto(string texto);
        Task<Option<string>> ObterPadraoPorTexto(string texto);
    }
}
