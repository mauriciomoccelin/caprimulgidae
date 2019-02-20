using Antilopes.InputModels;

namespace Caprimulgidae.Application.InputModels.Eventos
{
    public class CadastrarEventoInputModel : InputModel
    {
        public string Token { get; set; }
        public string Padrao { get; set; }
        public decimal ProbabilidadeAcontecer { get; set; }
    }
}
