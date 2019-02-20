using Caprimulgidae.Domain.Commands.Estimativas;
using Caprimulgidae.Domain.Properties;
using FluentValidation;

namespace Caprimulgidae.Domain.Validations.Estimativas
{
    public abstract class EstimativaValidator<TEstimativaCommand> : AbstractValidator<TEstimativaCommand> where TEstimativaCommand : EstimativaCommand
    {
        protected void ValidarTexto()
        {
            const string campo = "Texto";
            const byte minimo = 5;
            const byte maximo = 100;

            RuleFor(c => c.Texto)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo))
                .Length(minimo, maximo).WithMessage(string.Format(ValidationMessages.CampoDevePossuirUmValorMinimoEhMaximo, campo, minimo, maximo));
        }
    }
}
