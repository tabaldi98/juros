using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Soft.Taxa.Juros.Api;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Soft.Taxa.Juros.TestesIntegrados.Api.Controllers
{
    [TestFixture]
    public class TaxaJurosControllerTests
    {
        [Test]
        public async Task Deve_RetornarOk_Quando_BuscarTaxaDeJuros()
        {
            // Arrange
            var taxaDeJurosEsperada = 0.01M;
            var application = new WebApplicationFactory<Startup>();
            using var client = application.CreateClient();

            // Act
            var response = await client.GetAsync("/taxaJuros");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsAsync<decimal>();
            content.Should().Be(taxaDeJurosEsperada);
        }
    }
}
