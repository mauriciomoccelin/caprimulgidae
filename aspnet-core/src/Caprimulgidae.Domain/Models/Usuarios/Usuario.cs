using Antilopes.Domain.Core.Models;
using Antilopes.Domain.Core.Specifications;
using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Domain.Specifications.Usuarios;
using System;

namespace Caprimulgidae.Domain.Models.Usuarios
{
    public partial class Usuario : Entity<Usuario, Guid>, ISpecification
    {
        #region Propriedades
        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        #endregion
        #region Propriedades Computadas
        public string NomeCompleto => PrimeiroNome + " " + SegundoNome;

        public SpecificationResult SpecificationResult { get; private set; }
        #endregion
        #region Construtores
        protected Usuario() { }
        #endregion
        #region Metodos
        internal bool PodeSeAutenticar(IUsuarioReadOnlyRepository usuarioReadOnlyRepository)
        {
            var tarefa = new AutorizacaoUsuarioSpecification(usuarioReadOnlyRepository)
                .ValidateRulesFor(this);
            tarefa.Wait();
            SpecificationResult = tarefa.Result;
            return SpecificationResult.IsValid;
        }
        #endregion
    }
}
