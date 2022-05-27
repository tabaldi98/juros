using FluentAssertions;
using Moq;
using NUnit.Framework;
using Soft.Calculo.Juros.Domain.EntidadeJuros;
using Soft.Calculo.Juros.Domain.EntidadeJuros.CalculaJuros;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.TestesUnitarios.Domain.EntidadeJuros.CalculaJuros
{
    [TestFixture]
    public class CalculaJurosCommandHandlerTests
    {
        public Mock<IJuroRepositorio> _mockJuroRepositorio;

        [SetUp]
        public void Setup()
        {
            _mockJuroRepositorio = new Mock<IJuroRepositorio>(MockBehavior.Strict);
        }

        [Test]
        public async Task Deve_VerificarValor_Quando_CalcularJuros()
        {
            // Arrange
            var taxaJuros = 0.01M;
            var valorInicial = 100;
            var meses = 5;
            var command = new CalculaJurosCommand()
            {
                ValorInicial = valorInicial,
                Meses = meses,
            };

            _mockJuroRepositorio
                .Setup(p => p.BuscarTaxaDeJuro())
                .ReturnsAsync(taxaJuros);

            // Act
            var result = await BuscarHandler().Handle(command, It.IsAny<CancellationToken>());

            // Assert
            result.Should().Be("105.10");

            _mockJuroRepositorio.Verify(p => p.BuscarTaxaDeJuro());
        }

        [Test]
        public void Deve_OcorrerExcecao_Quando_CalcularJuros_Com_ApiDeTaxaIndisponivel()
        {
            // Arrange
            var exceptionMessage = "mock-exception";
            var command = new CalculaJurosCommand()
            {
                ValorInicial = 100,
                Meses = 5,
            };

            _mockJuroRepositorio
                .Setup(p => p.BuscarTaxaDeJuro())
                .ThrowsAsync(new ArgumentOutOfRangeException(exceptionMessage));

            // Act
            var result = Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => BuscarHandler().Handle(command, It.IsAny<CancellationToken>()));

            // Assert
            result.Message.Should().Contain(exceptionMessage);

            _mockJuroRepositorio.Verify(p => p.BuscarTaxaDeJuro());
        }

        private CalculaJurosCommandHandler BuscarHandler()
        {
            return new CalculaJurosCommandHandler(_mockJuroRepositorio.Object);
        }
    }
}
