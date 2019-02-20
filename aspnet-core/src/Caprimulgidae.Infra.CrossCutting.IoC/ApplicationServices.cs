using Caprimulgidae.Application.Interfaces;
using Caprimulgidae.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Caprimulgidae.Infra.CrossCutting.IoC
{
    public sealed class ApplicationServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IEstimativaAppService, EstimativaAppService>();
        }
    }
}
