using Antilopes.Domain.Core.UoW;
using Caprimulgidae.Domain.Interfaces.Estimativas;
using Caprimulgidae.Domain.Interfaces.Eventos;
using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Infra.Data.Context;
using Caprimulgidae.Infra.Data.Repositorys.Estimativas;
using Caprimulgidae.Infra.Data.Repositorys.Eventos;
using Caprimulgidae.Infra.Data.Repositorys.Usuarios;
using Caprimulgidae.Infra.Data.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caprimulgidae.Infra.CrossCutting.IoC
{
    public sealed class RepositoryServices
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CaprimulgidaeContext>();

            services.AddScoped<IEstimativaDomainRepository, EstimativaDomainRepository>();

            services.AddScoped<IEventoDomainRepository, EventoDomainRepository>();
            services.AddScoped<IEventoReadOnlyRepository, EventoReadOnlyRepository>();

            services.AddScoped<IUsuarioDomainRepository, UsuarioDomainRepository>();
            services.AddScoped<IUsuarioReadOnlyRepository, UsuarioReadOnlyRepository>();
        }
    }
}
