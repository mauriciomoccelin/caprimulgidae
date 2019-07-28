using Antilopes.Tests;
using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Infra.Data.Repositorys.Usuarios;
using Xunit;
using FluentAssertions;

namespace Caprimulgidae.Infra.Data.Test.Usuarios
{
    public class UsuarioReadOnlyRepository_Test : BaseTestReadOnlyRepository
    {
        private readonly IUsuarioReadOnlyRepository usuarioReadOnlyRepository;

        public UsuarioReadOnlyRepository_Test()
        {
            usuarioReadOnlyRepository = new UsuarioReadOnlyRepository(appSettingsHelper);
        }

        [Fact]
        public void ExisteUsuarioParaEmailEhSenha()
        {
            var result = usuarioReadOnlyRepository.Awaiting(x => x.ExisteUsuarioParaEmailEhSenha("", ""));
            result.Should().NotThrow();
        }

        [Fact]
        public void ObterParaAutenticacao()
        {
            var result = usuarioReadOnlyRepository.Awaiting(x => x.ObterParaAutenticacao(""));
            result.Should().NotThrow();
        }
    }
}
