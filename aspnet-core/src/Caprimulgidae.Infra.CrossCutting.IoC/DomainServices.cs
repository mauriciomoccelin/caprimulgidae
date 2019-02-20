using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Notifications;
using Caprimulgidae.Infra.CrossCutting.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Caprimulgidae.Infra.CrossCutting.IoC
{
    public sealed class DomainServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
