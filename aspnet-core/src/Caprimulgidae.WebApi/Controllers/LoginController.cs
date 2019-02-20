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
    public class LoginController : ApiController
    {
        private readonly IUsuarioAppService usuarioAppService;
        public LoginController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IUsuarioAppService usuarioAppService)
            : base(notifications, mediator)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpPost, Route("autenticar"), AllowAnonymous, ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> Autenticar([FromBody]AutenticarUsuarioInputModel inputModel) =>
            Response(await usuarioAppService.Autenticar(inputModel.Email, inputModel.Senha));
    }
}