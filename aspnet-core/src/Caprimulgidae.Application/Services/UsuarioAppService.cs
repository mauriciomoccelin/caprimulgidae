using Antilopes.Domain.Core.Bus;
using AutoMapper;
using Caprimulgidae.Application.InputModels.Usuarios;
using Caprimulgidae.Application.Interfaces;
using Caprimulgidae.Domain.Commands.Usuarios;
using Optional;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Application.Services
{
    public sealed class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler bus;

        public UsuarioAppService(
            IMapper mapper,
            IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<string> Autenticar(string email, string senha) =>
            (await bus.SendCommand<AutenticarUsuarioCommand, Option<string>>(
                AutenticarUsuarioCommand.Criar(email, senha))
            ).Match(
                some: token => token,
                none: () => string.Empty);

        public async Task Registrar(RegistrarUsuarioInputModel inputModel) =>
            await bus.SendCommand(mapper.Map<RegistrarUsuarioCommand>(inputModel));

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
