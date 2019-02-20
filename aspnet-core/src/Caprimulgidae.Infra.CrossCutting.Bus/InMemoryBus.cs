using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Commands;
using Antilopes.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace Caprimulgidae.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator _mediator) => this._mediator = _mediator;

        public Task SendCommand<T>(T command) where T : Command => _mediator.Send(command);

        public Task RaiseEvent<T>(T @event) where T : Event => _mediator.Publish(@event);

        public Task<TResponse> SendCommand<TCommand, TResponse>(TCommand command)
            where TCommand : Command
            where TResponse : struct => _mediator.Send(command as IRequest<TResponse>);
    }
}
