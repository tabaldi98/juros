using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soft.Calculo.Juros.Domain.EntidadeMeuCodigo;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.Api.Controllers
{
    [Route("showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ShowMeTheCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarLinkDoProjetoNoGitHub()
        {
            return Ok(await _mediator.Send(new MeuCodigoQuery()));
        }
    }
}
