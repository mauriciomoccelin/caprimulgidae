using Antilopes.Domain.Core.Specifications;
using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Domain.Models.Usuarios;
using System.Threading.Tasks;

namespace Caprimulgidae.Domain.Specifications.Usuarios
{
    public abstract class UsuarioSpecification<TUsuario> : BaseSpecification<TUsuario> where TUsuario : Usuario
    {
        protected async Task<bool> ValidarCredenciais(
            IUsuarioReadOnlyRepository usuarioReadOnlyRepository,
            TUsuario candidate)
        {
            return await usuarioReadOnlyRepository.ExisteUsuarioParaEmailEhSenha(
                candidate.Email,
                candidate.Senha);
        }
    }
}
