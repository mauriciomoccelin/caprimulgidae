using Antilopes.Domain.Core.Repositorys;
using Caprimulgidae.Domain.Models.Usuarios;
using System;

namespace Caprimulgidae.Domain.Interfaces.Usuarios
{
    public interface IUsuarioDomainRepository : IDomainRepository<Usuario, Guid>
    {
    }
}
