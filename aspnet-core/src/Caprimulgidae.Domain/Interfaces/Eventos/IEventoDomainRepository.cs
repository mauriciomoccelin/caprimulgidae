using Antilopes.Domain.Core.Repositorys;
using Caprimulgidae.Domain.Models.Eventos;
using System;

namespace Caprimulgidae.Domain.Interfaces.Eventos
{
    public interface IEventoDomainRepository : IDomainRepository<Evento, Guid>
    {
    }
}
