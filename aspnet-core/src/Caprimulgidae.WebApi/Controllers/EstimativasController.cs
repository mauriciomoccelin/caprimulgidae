using Antilopes.Domain.Core.Bus;
using Antilopes.Domain.Core.Notifications;
using Antilopes.WebApi.Controlers;
using Caprimulgidae.Application.Interfaces;
using Caprimulgidae.Domain.ViewModels.Estimativas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Caprimulgidae.WebApi.Controllers
{
    public class EstimativasController : ApiController
    {
        private readonly IEstimativaAppService estimativaAppService;

        public EstimativasController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IEstimativaAppService estimativaAppService)
            : base(notifications, mediator)
        {
            this.estimativaAppService = estimativaAppService;
        }

        [HttpGet, Route("estimativa-por-bayes-usando-texto/{texto}"), Authorize, ProducesResponseType(typeof(EstimativaPorBayesViewModel), 200)]
        public async Task<IActionResult> EstimativaPorBayesUsandoTexto([FromRoute]string texto) =>
            Response(await estimativaAppService.EstimativaPorBayesUsandoTexto(texto));
    }
}
