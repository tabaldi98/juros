using MediatR;
using Soft.Calculo.Juros.Infra.Extensoes;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.Domain.EntidadeJuros.CalculaJuros
{
    public class CalculaJurosCommandHandler : IRequestHandler<CalculaJurosCommand, string>
    {
        private readonly IJuroRepositorio _juroRepositorio;

        public CalculaJurosCommandHandler(IJuroRepositorio juroRepositorio)
        {
            _juroRepositorio = juroRepositorio;
        }

        public async Task<string> Handle(CalculaJurosCommand request, CancellationToken cancellationToken)
        {
            var taxaJuros = await _juroRepositorio.BuscarTaxaDeJuro();

            var juro = new Juro(request.ValorInicial, taxaJuros, request.Meses);

            return juro.CalcularJuros().FormatarCasasDecimais();
        }
    }
}
