using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Caprimulgidae.Domain.Models.Usuarios
{
    public partial class Usuario
    {
        internal static Usuario CriarParaRegistrar(
            string primeiroNome,
            string segundoNome,
            string email,
            string senha) =>
            new Usuario()
            {
                PrimeiroNome = primeiroNome.ToUpper(),
                SegundoNome = segundoNome.ToUpper(),
                Email = email.ToUpper(),
                Senha = CriptografarSenha(senha)
            };

        internal static Usuario CriarAutenticar(
            string email,
            string senha) =>
            new Usuario()
            {
                Email = email.ToUpper(),
                Senha = CriptografarSenha(senha)
            };

        private static string CriptografarSenha(string senha)
        {
            using (SHA256 hash = SHA256.Create())
            {
                return string.Concat(
                    hash.ComputeHash(Encoding.UTF8.GetBytes(senha))
                    .Select(x => x.ToString("x2")));
            }
        }
    }
}
