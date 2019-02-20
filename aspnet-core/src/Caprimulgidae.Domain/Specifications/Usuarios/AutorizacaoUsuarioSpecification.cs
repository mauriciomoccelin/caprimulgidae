using Antilopes.Domain.Core.Specifications;
using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Domain.Models.Usuarios;
using System.Threading.Tasks;

namespace Caprimulgidae.Domain.Specifications.Usuarios
{
    public sealed class AutorizacaoUsuarioSpecification : UsuarioSpecification<Usuario>
    {
        private readonly IUsuarioReadOnlyRepository usuarioReadOnlyRepository;
        public AutorizacaoUsuarioSpecification(IUsuarioReadOnlyRepository usuarioReadOnlyRepository)
        {
            this.usuarioReadOnlyRepository = usuarioReadOnlyRepository;
        }

        public override Task<SpecificationResult> ValidateRulesFor(Usuario candidate) =>
            ValidationWrapper(async specification => await Validar(usuarioReadOnlyRepository, specification, candidate));

        private async Task Validar(
            IUsuarioReadOnlyRepository usuarioReadOnlyRepository,
            SpecificationResult specification,
            Usuario candidate)
        {
            if (!(await ValidarCredenciais(usuarioReadOnlyRepository, candidate)))
                specification.Errors.Add(SpecificationError.Create(
                    nameof(ValidarCredenciais), "Credenciais inválidas"));
        }
    }
}
