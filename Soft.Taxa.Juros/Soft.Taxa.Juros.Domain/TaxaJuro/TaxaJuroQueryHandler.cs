using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Taxa.Juros.Domain.TaxaJuro
{
    public class TaxaJuroQueryHandler : IRequestHandler<TaxaJuroQuery, decimal>
    {
        private readonly IConfiguration _configuration;

        public TaxaJuroQueryHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<decimal> Handle(TaxaJuroQuery request, CancellationToken cancellationToken)
        {
            if (!decimal.TryParse(_configuration["TaxaDeJuros"], out var taxaJuros))
            {
                throw new ArgumentOutOfRangeException("A taxa de juros configurada está com um valor incorreto!");
            }

            return Task.FromResult(taxaJuros);
        }
    }
}
