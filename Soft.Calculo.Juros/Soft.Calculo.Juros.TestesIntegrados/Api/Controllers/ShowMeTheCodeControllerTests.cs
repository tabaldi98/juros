using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Soft.Calculo.Juros.Api;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.TestesIntegrados.Api.Controllers
{
    [TestFixture]
    public class ShowMeTheCodeControllerTests
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
        public async Task Deve_RetornarOk_Quando_BuscarLinkDoProjeto()
        {
            // Arrange
            var linkEsperado = "https://github.com/tabaldi98/juros.git";

            // Act
            var response = await _client.GetAsync("/showmethecode");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be(linkEsperado);
        }
    }
}
