using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using Soft.Taxa.Juros.Domain.TaxaJuro;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Taxa.Juros.TestesUnitarios.Domain.TaxaJuro
{
    [TestFixture]
    public class TaxaJuroQueryHandlerTests
    {
        public Mock<IConfiguration> _mockConfiguration;

        [SetUp]
        public void Setup()
        {
            _mockConfiguration = new Mock<IConfiguration>(MockBehavior.Strict);
        }

        [Test]
        public async Task Deve_RetornarTaxaDeJuro_Quando_BuscarTaxaDeJuros()
        {
            // Arrange
            var taxaJuros = 0.01M;

            _mockConfiguration
                .Setup(p => p["TaxaDeJuros"])
                .Returns(taxaJuros.ToString());

            // Act
            var result = await BuscarHandler().Handle(new TaxaJuroQuery(), It.IsAny<CancellationToken>());

            // Assert
            result.Should().Be(taxaJuros);
        }

        [Test]
        public void Deve_RetornarArgumentOutOfRangeException_Quando_BuscarTaxaDeJuros_Com_ValorConfiguradoInvalido()
        {
            // Arrange
            _mockConfiguration
                .Setup(p => p["TaxaDeJuros"])
                .Returns("mock-invalid-value");

            // Act
            var result = Assert.Throws<ArgumentOutOfRangeException>(() => BuscarHandler().Handle(new TaxaJuroQuery(), It.IsAny<CancellationToken>()));

            // Assert
            result.Message.Should().Contain("A taxa de juros configurada está com um valor incorreto!");
        }

        private TaxaJuroQueryHandler BuscarHandler()
        {
            return new TaxaJuroQueryHandler(_mockConfiguration.Object);
        }
    }
}
