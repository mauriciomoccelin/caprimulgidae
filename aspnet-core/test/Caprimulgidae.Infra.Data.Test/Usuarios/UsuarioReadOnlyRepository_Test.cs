using Antilopes.Tests;
using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Infra.Data.Repositorys.Usuarios;
using System.Threading.Tasks;
using Xunit;

namespace Caprimulgidae.Infra.Data.Test.Usuarios
{
    public class UsuarioReadOnlyRepository_Test : BaseTestReadOnlyRepository<IUsuarioReadOnlyRepository, UsuarioReadOnlyRepository>
    {
        [Fact]
        public void ExisteUsuarioParaEmailEhSenha()
        {
            TestIfNotThrow(async x => await x.ExisteUsuarioParaEmailEhSenha("", ""));
            TestIfBeOfType(async () => await readOnlyRepository.ExisteUsuarioParaEmailEhSenha("", ""));
        }

        [Fact]
        public async void ObterParaAutenticacao()
        {
            await FactoryTestAsync(tasks =>
            {
                tasks.Add(Task.Run(() => TestIfNotThrow(async x => await x.ObterParaAutenticacao(""))));
                tasks.Add(Task.Run(() => TestIfBeOfType(async () => await readOnlyRepository.ObterParaAutenticacao(""))));
            });
        }
    }
}
