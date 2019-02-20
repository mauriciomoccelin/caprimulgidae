using Caprimulgidae.Domain.Commands.Eventos;

namespace Caprimulgidae.Domain.Validations.Eventos
{
    public class CadastrarEventoValidation : EventoValidation<CadastrarEventoCommand>
    {
        public CadastrarEventoValidation()
        {
            ValidarToken();
            ValidarPadrao();
            ValidarProbabilidadeAcontecer();
        }
    }
}
