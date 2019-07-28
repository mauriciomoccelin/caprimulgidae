using Antilopes.Common.Helpers.AppSettings;
using Antilopes.Repository.Dapper.SQLServer;

namespace Caprimulgidae.Infra.Data.Repositorys
{
    public abstract class ReadOnlyRepository : SQLServerDapperRepository
    {
        public ReadOnlyRepository(IAppSettingsHelper appSettingsHelper) : base(appSettingsHelper.GetConnectionString()) { }
    }
}
