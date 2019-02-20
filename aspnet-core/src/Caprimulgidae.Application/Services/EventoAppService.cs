
using AutoMapper;
using Caprimulgidae.Application.InputModels.Eventos;
using Caprimulgidae.Application.Interfaces;
using Caprimulgidae.Domain.Commands.Eventos;
using Antilopes.Domain.Core.Bus;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Application.Services
{
    public sealed class EventoAppService : IEventoAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler bus;

        public EventoAppService(
            IMapper mapper,
            IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task Cadastrar(CadastrarEventoInputModel inputModel) =>
            await bus.SendCommand(mapper.Map<CadastrarEventoCommand>(inputModel));

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
