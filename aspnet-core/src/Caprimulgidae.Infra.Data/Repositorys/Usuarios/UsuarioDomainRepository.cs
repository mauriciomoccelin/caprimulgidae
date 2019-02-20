using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Domain.Models.Usuarios;
using Caprimulgidae.Infra.Data.Context;
using System;

namespace Caprimulgidae.Infra.Data.Repositorys.Usuarios
{
    public sealed class UsuarioDomainRepository : DomainRepository<Usuario, Guid>, IUsuarioDomainRepository
    {
        public UsuarioDomainRepository(CaprimulgidaeContext context) : base(context) { }
    }
}
