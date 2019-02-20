using Antilopes.InputModels;

namespace Caprimulgidae.Application.InputModels.Usuarios
{
    public class RegistrarUsuarioInputModel : InputModel
    {
        public string PrimeiroNome { get; set; }
        public string SegundoNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
