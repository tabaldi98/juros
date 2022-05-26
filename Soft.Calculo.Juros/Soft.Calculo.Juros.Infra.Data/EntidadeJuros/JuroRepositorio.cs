using Soft.Calculo.Juros.Domain.EntidadeJuros;
using System.Net.Http;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.Infra.Data.EntidadeJuros
{
    public class JuroRepositorio : IJuroRepositorio
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public JuroRepositorio(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        public async Task<decimal> BuscarTaxaDeJuro()
        {
            using (var client = _httpClientFactory.CreateClient(Constantes.TAXA_JUROS_HTTP_CLIENT_NOME))
            {
                var response = await client.GetAsync("/taxaJuros");

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<decimal>();
            }
        }
    }
}
