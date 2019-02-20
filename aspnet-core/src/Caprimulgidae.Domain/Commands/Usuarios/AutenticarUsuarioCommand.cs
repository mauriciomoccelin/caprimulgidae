using Caprimulgidae.Domain.Validations.Usuarios;
using MediatR;
using Optional;

namespace Caprimulgidae.Domain.Commands.Usuarios
{
    public sealed class AutenticarUsuarioCommand : UsuarioCommand, IRequest<Option<string>>
    {
        private AutenticarUsuarioCommand() { }

        public static AutenticarUsuarioCommand Criar(string email, string senha) =>
            new AutenticarUsuarioCommand()
            {
                Email = email,
                Senha = senha
            };

        public override bool IsValid()
        {
            ValidationResult = new AutenticarUsuarioValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
