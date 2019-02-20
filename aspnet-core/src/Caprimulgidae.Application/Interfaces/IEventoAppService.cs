using Caprimulgidae.Application.InputModels.Eventos;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Application.Interfaces
{
    public interface IEventoAppService : IDisposable
    {
        Task Cadastrar(CadastrarEventoInputModel inputModel);
    }
}
