using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Commands;
using Antilopes.Domain.Core.Notifications;
using Antilopes.Domain.Core.UoW;
using Antilopes.Identity;
using Caprimulgidae.Domain.Commands.Usuarios;
using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Domain.Models.Usuarios;
using Caprimulgidae.Domain.ViewModels.Usuarios;
using MediatR;
using Optional;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Caprimulgidae.Domain.CommandHandlers
{
    public sealed class UsuarioCommandHandlers :
        CommandHandler,
        IRequestHandler<RegistrarUsuarioCommand>,
        IRequestHandler<AutenticarUsuarioCommand, Option<string>>
    {
        private readonly IUsuarioDomainRepository usuarioDomainRepository;
        private readonly IUsuarioReadOnlyRepository usuarioReadOnlyRepository;
        private readonly IMediatorHandler bus;
        private readonly IIdentityManager identityManager;

        public UsuarioCommandHandlers(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IUsuarioDomainRepository usuarioDomainRepository,
            IUsuarioReadOnlyRepository usuarioReadOnlyRepository,
            IIdentityManager identityManager)
            : base(uow, bus, notifications)
        {
            this.bus = bus;
            this.identityManager = identityManager;
            this.usuarioDomainRepository = usuarioDomainRepository;
            this.usuarioReadOnlyRepository = usuarioReadOnlyRepository;
        }

        public async Task<Unit> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return await Unit.Task;

            var usuario = Usuario.CriarParaRegistrar(
                request.PrimeiroNome,
                request.SegundoNome,
                request.Email,
                request.SegundoNome);

            await usuarioDomainRepository.Add(usuario);
            await Commit();

            return await Unit.Task;
        }

        public async Task<Option<string>> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return Option.None<string>();
            var usuario = Usuario.CriarAutenticar(request.Email, request.Senha);

            if (!usuario.PodeSeAutenticar(usuarioReadOnlyRepository))
            {
                NotifyValidationErrors(usuario);
                return Option.None<string>();
            }

            var usuarioViewModel = (await usuarioReadOnlyRepository.ObterParaAutenticacao(usuario.Email))
                .ValueOr(AutorizacaoUsuarioViewModel.Empty());

            var identityUser = identityManager.CreateUser(
                    usuarioViewModel.NomeCompleto,
                    usuarioViewModel.Email,
                    Enumerable.Empty<string>())
                    .ValueOr(UserIdentity.Empty());

            return identityManager.GenereteAccessToken(identityUser);
        }

        public override void Dispose()
        {
            usuarioDomainRepository.Dispose();
            usuarioReadOnlyRepository.Dispose();
        }
    }
}
