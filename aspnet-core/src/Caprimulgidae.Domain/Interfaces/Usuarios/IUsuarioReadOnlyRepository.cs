using Antilopes.Domain.Core.Repositorys;
using Caprimulgidae.Domain.ViewModels.Usuarios;
using Optional;
using System.Threading.Tasks;

namespace Caprimulgidae.Domain.Interfaces.Usuarios
{
    public interface IUsuarioReadOnlyRepository : IReadOnlyRepository
    {
        Task<bool> ExisteUsuarioParaEmailEhSenha(string email, string senha);
        Task<Option<AutorizacaoUsuarioViewModel>> ObterParaAutenticacao(string email);
    }
}
