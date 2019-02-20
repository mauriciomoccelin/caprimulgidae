using Antilopes.Domain.Core.UoW;
using Caprimulgidae.Infra.Data.Context;
using System.Threading.Tasks;

namespace Caprimulgidae.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CaprimulgidaeContext caprimulgidaeContext;

        public UnitOfWork(CaprimulgidaeContext caprimulgidaeContext) =>
            this.caprimulgidaeContext = caprimulgidaeContext;

        public async Task<bool> Commit() => await caprimulgidaeContext.SaveChangesAsync() > 0;

        public void Dispose() => caprimulgidaeContext.Dispose();
    }
}
