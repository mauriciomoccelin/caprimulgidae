using Caprimulgidae.Domain.Commands.Usuarios;
using Caprimulgidae.Domain.Properties;
using FluentValidation;

namespace Caprimulgidae.Domain.Validations.Usuarios
{
    public abstract class UsuarioValidator<T> : AbstractValidator<T> where T : UsuarioCommand
    {
        protected void ValidarId()
        {
            const string campo = "Id";

            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo));
        }

        protected void ValidarPrimeiroNome()
        {
            const string campo = "Primeiro Nome";
            const byte minimo = 5;
            const byte maximo = 100;

            RuleFor(c => c.PrimeiroNome)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo))
                .Length(minimo, maximo).WithMessage(string.Format(ValidationMessages.CampoDevePossuirUmValorMinimoEhMaximo, campo, minimo, maximo));
        }

        protected void ValidarSegundoNome()
        {
            const string campo = "Segundo Nome";
            const byte minimo = 5;
            const byte maximo = 100;

            RuleFor(c => c.SegundoNome)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo))
                .Length(minimo, maximo).WithMessage(string.Format(ValidationMessages.CampoDevePossuirUmValorMinimoEhMaximo, campo, minimo, maximo));
        }

        protected void ValidarEmail()
        {
            const string campo = "Email";
            const byte minimo = 5;
            const byte maximo = 100;

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo))
                .Length(minimo, maximo).WithMessage(string.Format(ValidationMessages.CampoDevePossuirUmValorMinimoEhMaximo, campo, minimo, maximo))
                .EmailAddress().WithMessage(x => string.Format(ValidationMessages.EmailInvalido, x.Email));
        }

        protected void ValidarSenha()
        {
            const string campo = "Senha";
            const byte minimo = 5;
            const byte maximo = 100;

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage(string.Format(ValidationMessages.CampoObrigatorio, campo))
                .Length(minimo, maximo).WithMessage(string.Format(ValidationMessages.CampoDevePossuirUmValorMinimoEhMaximo, campo, minimo, maximo));
        }
    }
}
