using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using Soft.Calculo.Juros.Domain.EntidadeMeuCodigo;
using Soft.Calculo.Juros.Infra;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.TestesUnitarios.Domain.EntidadeMeuCodigo
{
    [TestFixture]
    public class MeuCodigoQueryHandlerTests
    {
        public Mock<IConfiguration> _mockConfiguration;

        [SetUp]
        public void Setup()
        {
            _mockConfiguration = new Mock<IConfiguration>(MockBehavior.Strict);
        }

        [Test]
        public async Task Deve_RetornarLink_Quando_BuscarLinkDoCodigoFonteDoGitHub()
        {
            // Arrange
            var linkEsperado = "https://github.com/tabaldi98/juros.git";

            _mockConfiguration
                .Setup(p => p[Constantes.ENDERECO_REPOSITORIO_GITHUB])
                .Returns(linkEsperado);

            // Act
            var result = await new MeuCodigoQueryHandler(_mockConfiguration.Object).Handle(new MeuCodigoQuery(), It.IsAny<CancellationToken>());

            // Assert
            result.Should().Be(linkEsperado);

            _mockConfiguration.Verify(p => p[Constantes.ENDERECO_REPOSITORIO_GITHUB]);
        }
    }
}
