using Caprimulgidae.Domain.Validations.Estimativas;
using Caprimulgidae.Domain.ViewModels.Estimativas;
using MediatR;
using Optional;

namespace Caprimulgidae.Domain.Commands.Estimativas
{
    public sealed class EstimativaBayesPorTextoCommand : EstimativaCommand, IRequest<Option<EstimativaPorBayesViewModel>>
    {
        public static EstimativaBayesPorTextoCommand Criar(string texto) =>
            new EstimativaBayesPorTextoCommand()
            {
                Texto = texto
            };

        public override bool IsValid()
        {
            ValidationResult = new EstimativaBayesPorTextoValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
