using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soft.Taxa.Juros.Domain.TaxaJuro;
using System.Threading.Tasks;

namespace Soft.Taxa.Juros.Api.Controllers
{
    [Route("taxaJuros")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        public readonly IMediator _mediator;

        public TaxaJurosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTaxaDeJuros()
        {
            return Ok(await _mediator.Send(new TaxaJuroQuery()));
        }
    }
}
