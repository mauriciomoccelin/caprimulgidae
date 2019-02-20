using Caprimulgidae.Domain.Commands.Estimativas;

namespace Caprimulgidae.Domain.Validations.Estimativas
{
    public class EstimativaBayesPorTextoValidator : EstimativaValidator<EstimativaBayesPorTextoCommand>
    {
        public EstimativaBayesPorTextoValidator()
        {
            ValidarTexto();
        }
    }
}
