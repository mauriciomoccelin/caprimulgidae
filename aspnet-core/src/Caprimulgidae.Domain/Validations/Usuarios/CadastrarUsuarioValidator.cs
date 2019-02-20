using Caprimulgidae.Domain.Commands.Usuarios;

namespace Caprimulgidae.Domain.Validations.Usuarios
{
    public class CadastrarUsuarioValidator : UsuarioValidator<RegistrarUsuarioCommand>
    {
        public CadastrarUsuarioValidator()
        {
            ValidarPrimeiroNome();
            ValidarSegundoNome();
            ValidarEmail();
            ValidarSenha();
        }
    }
}
