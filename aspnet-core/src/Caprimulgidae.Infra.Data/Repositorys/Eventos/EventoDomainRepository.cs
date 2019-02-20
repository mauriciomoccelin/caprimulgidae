using Caprimulgidae.Domain.Interfaces.Eventos;
using Caprimulgidae.Domain.Models.Eventos;
using Caprimulgidae.Infra.Data.Context;
using System;

namespace Caprimulgidae.Infra.Data.Repositorys.Eventos
{
    public sealed class EventoDomainRepository : DomainRepository<Evento, Guid>, IEventoDomainRepository
    {
        public EventoDomainRepository(CaprimulgidaeContext context) : base(context) { }
    }
}
