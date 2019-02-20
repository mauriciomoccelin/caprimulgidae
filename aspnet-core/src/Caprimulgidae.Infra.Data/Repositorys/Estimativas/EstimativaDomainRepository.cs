using Caprimulgidae.Domain.Interfaces.Estimativas;
using Caprimulgidae.Domain.Models.Estimativas;
using Caprimulgidae.Infra.Data.Context;
using System;

namespace Caprimulgidae.Infra.Data.Repositorys.Estimativas
{
    public sealed class EstimativaDomainRepository : DomainRepository<Estimativa, Guid>, IEstimativaDomainRepository
    {
        public EstimativaDomainRepository(CaprimulgidaeContext context) : base(context) { }
    }
}
