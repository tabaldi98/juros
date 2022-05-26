using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Soft.Calculo.Juros.Api;
using Soft.Calculo.Juros.Domain.EntidadeJuros.CalculaJuros;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.TestesIntegrados.Api.Controllers
{
    [TestFixture]
    public class TaxaJurosControllerTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var application = new WebApplicationFactory<Startup>();
            _client = application.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }

        [Test]
        public async Task Deve_RetornarOk_Quando_CalcularJuros()
        {
            // Arrange
            var valorEsperado = "105.10";

            // Act
            var response = await _client.PostAsJsonAsync("/calculaJuros", new CalculaJurosCommand()
            {
                ValorInicial = 100,
                Meses = 5,
            });

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be(valorEsperado);
        }

        [TestCase(0, 1, TestName = "Deve_RetornarBadRequest_Quando_CalcularJuros_Com_ValorInicialZero")]
        [TestCase(1, 0, TestName = "Deve_RetornarBadRequest_Quando_CalcularJuros_Com_MesesZero")]
        public async Task Deve_RetornarBadRequest_Quando_CalcularJuros_Com_BodyInvalido(int valorInicial, int meses)
        {
            // Act
            var response = await _client.PostAsJsonAsync("/calculaJuros", new CalculaJurosCommand()
            {
                ValorInicial = valorInicial,
                Meses = meses,
            });

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
