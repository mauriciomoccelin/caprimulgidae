using Caprimulgidae.Application.InputModels.Usuarios;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task Registrar(RegistrarUsuarioInputModel inputModel);
        Task<string> Autenticar(string email, string senha);
    }
}
