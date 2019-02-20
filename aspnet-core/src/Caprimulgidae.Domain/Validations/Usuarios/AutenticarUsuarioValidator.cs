using Caprimulgidae.Domain.Commands.Usuarios;

namespace Caprimulgidae.Domain.Validations.Usuarios
{
    public class AutenticarUsuarioValidator : UsuarioValidator<AutenticarUsuarioCommand>
    {
        public AutenticarUsuarioValidator()
        {
            ValidarEmail();
            ValidarSenha();
        }
    }
}
