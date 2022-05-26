using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soft.Calculo.Juros.Domain.EntidadeJuros.CalculaJuros;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.Api.Controllers
{
    [Route("calculaJuros")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CalculaJurosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CalcularJuros([FromBody] CalculaJurosCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
