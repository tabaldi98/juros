using MediatR;
using Microsoft.Extensions.Configuration;
using Soft.Calculo.Juros.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.Domain.EntidadeMeuCodigo
{
    public class MeuCodigoQueryHandler : IRequestHandler<MeuCodigoQuery, string>
    {
        private readonly IConfiguration _configuration;

        public MeuCodigoQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<string> Handle(MeuCodigoQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_configuration[Constantes.ENDERECO_REPOSITORIO_GITHUB]);
        }
    }
}
