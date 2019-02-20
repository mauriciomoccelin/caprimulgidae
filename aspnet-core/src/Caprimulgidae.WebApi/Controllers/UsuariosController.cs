using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Notifications;
using Antilopes.WebApi.Controlers;
using Caprimulgidae.Application.InputModels.Usuarios;
using Caprimulgidae.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Caprimulgidae.WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioAppService usuarioAppService;
        public UsuariosController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IUsuarioAppService usuarioAppService)
            : base(notifications, mediator)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpPost, Route("registrar"), AllowAnonymous]
        public async Task<IActionResult> Cadastrar([FromBody]RegistrarUsuarioInputModel inputModel)
        {
            await usuarioAppService.Registrar(inputModel);
            return Response();
        }
    }
}