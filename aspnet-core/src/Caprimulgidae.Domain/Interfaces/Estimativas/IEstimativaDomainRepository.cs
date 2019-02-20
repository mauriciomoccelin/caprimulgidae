using Antilopes.Domain.Core.Repositorys;
using Caprimulgidae.Domain.Models.Estimativas;
using System;

namespace Caprimulgidae.Domain.Interfaces.Estimativas
{
    public interface IEstimativaDomainRepository : IDomainRepository<Estimativa, Guid>
    {
    }
}
