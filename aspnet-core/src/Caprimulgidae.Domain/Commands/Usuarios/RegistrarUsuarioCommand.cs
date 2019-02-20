using Caprimulgidae.Domain.Validations.Usuarios;

namespace Caprimulgidae.Domain.Commands.Usuarios
{
    public sealed class RegistrarUsuarioCommand : UsuarioCommand
    {
        private RegistrarUsuarioCommand() { }

        public static RegistrarUsuarioCommand Criar(
            string primeiroNome,
            string segundoNome,
            string email,
            string senha) =>
            new RegistrarUsuarioCommand()
            {
                PrimeiroNome = primeiroNome,
                SegundoNome = segundoNome,
                Email = email,
                Senha = senha
            };

        public override bool IsValid()
        {
            ValidationResult = new CadastrarUsuarioValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
