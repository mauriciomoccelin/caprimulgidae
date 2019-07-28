using Antilopes.Common.Helpers.AppSettings;
using Caprimulgidae.Domain.Interfaces.Eventos;
using Caprimulgidae.Domain.ViewModels.Eventos;
using Optional;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Caprimulgidae.Infra.Data.Repositorys.Eventos
{
    public sealed class EventoReadOnlyRepository : ReadOnlyRepository, IEventoReadOnlyRepository
    {
        public EventoReadOnlyRepository(IAppSettingsHelper appSettingsHelper) : base (appSettingsHelper){ }

        protected override string PrincipalTable => nameof(Eventos);

        public async Task<Option<IEnumerable<EventoViewModel>>> ObterEventosPorTexto(string texto)
        {
            var padrao = (await ObterPadraoPorTexto(texto)).ValueOr(string.Empty);
            var tokensParaProcura = Regex.Matches(texto, padrao, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            var command = BuildCommand(
                fields: ObterCampos(),
                conditions: BuildConditions(
                    ObterFiltroPadroes(tokensParaProcura.Select(x => x.Value).ToArray())));

            return await ExecuteQuery<EventoViewModel>(command);
        }

        public async Task<Option<string>> ObterPadraoPorTexto(string texto)
        {
            var command = BuildCommand(new[] { ObterExpressaoParaConstruirRegex() });
            return await ExecuteQuerySingle<string>(command);
        }

        #region Metodos privados
        private string[] ObterCampos() =>
            new string[]
            {
                CampoToken,
                CampoPadrao,
                CampoProbabilidadeAcontecer,
                CampoProbabilidadeNaoAcontecer
            };
        #endregion
        #region Campos
        const string CampoToken = "Token";
        const string CampoPadrao = "Padrao";
        const string CampoProbabilidadeAcontecer = "ProbabilidadeAcontecer";
        const string CampoProbabilidadeNaoAcontecer = "ProbabilidadeNaoAcontecer";
        #endregion
        #region Expressoes
        private string ObterExpressaoParaConstruirRegex() =>
            $"CONCAT('(?:', STRING_AGG({PrincipalTable}.{CampoPadrao}, '|'), ')')";
        #endregion
        #region Filtros
        private string ObterFiltroPadroes(string[] padroes) =>
            $"{PrincipalTable}.{CampoPadrao} IN {string.Join(",", padroes)}";
        #endregion
    }
}
