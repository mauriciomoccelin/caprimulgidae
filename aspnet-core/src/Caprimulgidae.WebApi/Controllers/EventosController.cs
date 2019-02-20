using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Notifications;
using Antilopes.WebApi.Controlers;
using Caprimulgidae.Application.InputModels.Eventos;
using Caprimulgidae.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Caprimulgidae.WebApi.Controllers
{
    public class EventosController : ApiController
    {
        private readonly IEventoAppService eventoAppService;
        public EventosController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IEventoAppService eventoAppService)
            : base(notifications, mediator)
        {
            this.eventoAppService = eventoAppService;
        }

        [HttpPost, Route("cadastrar"), Authorize]
        public async Task<IActionResult> Post([FromBody]CadastrarEventoInputModel inputModel)
        {
            await eventoAppService.Cadastrar(inputModel);
            return Response();
        }
    }
}
