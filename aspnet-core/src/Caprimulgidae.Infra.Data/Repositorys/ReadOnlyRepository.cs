using Antilopes.Repository.Dapper.SQLServer;

namespace Caprimulgidae.Infra.Data.Repositorys
{
    public abstract class ReadOnlyRepository : SQLServerDapperRepository
    {
        protected ReadOnlyRepository() : base(AppSettingsHelper.GetConnectionString()) { }
    }
}
