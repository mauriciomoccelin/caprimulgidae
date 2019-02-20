using Antilopes.InputModels;

namespace Caprimulgidae.Application.InputModels.Usuarios
{
    public class AutenticarUsuarioInputModel : InputModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
