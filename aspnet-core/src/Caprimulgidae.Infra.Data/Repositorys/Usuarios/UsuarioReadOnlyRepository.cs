using Caprimulgidae.Domain.Interfaces.Usuarios;
using Caprimulgidae.Domain.ViewModels.Usuarios;
using Optional;
using System.Threading.Tasks;

namespace Caprimulgidae.Infra.Data.Repositorys.Usuarios
{
    public sealed class UsuarioReadOnlyRepository : ReadOnlyRepository, IUsuarioReadOnlyRepository
    {
        public UsuarioReadOnlyRepository() { }

        protected override string PrincipalTable => nameof(Usuarios);

        public async Task<bool> ExisteUsuarioParaEmailEhSenha(string email, string senha) =>
            await ExistForCondition(GetConditionsWitnAnd(ObterFiltroEmail(email), ObterFiltroSenha(senha)));

        public async Task<Option<AutorizacaoUsuarioViewModel>> ObterParaAutenticacao(string email)
        {
            var command = BuildCommand(
                fields: ObterCampos(),
                conditions: BuildConditions(ObterFiltroEmail(email)));
            return await ExecuteQueryFirst<AutorizacaoUsuarioViewModel>(command);
        }

        #region Metodos privados
        private string[] ObterCampos() =>
            new string[]
            {
                CampoPrimeiroNome,
                CampoSegundoNome,
                CampoEmail,
                CampoSenha
            };
        #endregion
        #region Campos
        const string CampoPrimeiroNome = "PrimeiroNome";
        const string CampoSegundoNome = "SegundoNome";
        const string CampoEmail = "Email";
        const string CampoSenha = "Senha";
        #endregion
        #region Filtros
        private string ObterFiltroEmail(string email) => $"{CampoEmail} = @{AddParameter(email)}";
        private string ObterFiltroSenha(string senha) => $"{CampoSenha} = @{AddParameter(senha)}";
        #endregion
    }
}
