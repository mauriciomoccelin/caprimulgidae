using Caprimulgidae.Domain.Commands.Eventos;
using Caprimulgidae.Domain.Properties;
using FluentValidation;

namespace Caprimulgidae.Domain.Validations.Eventos
{
    public abstract class EventoValidation<T> : AbstractValidator<T> where T : EventoCommand
    {
        protected void ValidarId()
        {
            const string campo = "Id";

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo));
        }

        protected void ValidarProbabilidadeAcontecer()
        {
            const string campo = "Probabilidade de o Evento Acontecer";
            const decimal minimo = 1m;
            const decimal maximo = 100m;

            RuleFor(c => c.ProbabilidadeAcontecer)
                .Must(x => x > minimo || x < maximo).WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo));
        }

        protected void ValidarToken()
        {
            const string campo = "Token";
            const byte minimo = 5;
            const byte maximo = 100;

            RuleFor(c => c.Token)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo))
                .Length(minimo, maximo).WithMessage(string.Format(ValidationMessages.CampoDevePossuirUmValorMinimoEhMaximo, campo, minimo, maximo));
        }

        protected void ValidarPadrao()
        {
            const string campo = "Padrão";
            const byte minimo = 2;
            const byte maximo = 100;

            RuleFor(c => c.Padrao)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo))
                .Length(minimo, maximo).WithMessage(string.Format(ValidationMessages.CampoDevePossuirUmValorMinimoEhMaximo, campo, minimo, maximo));
        }
    }
}
