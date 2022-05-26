using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Soft.Taxa.Juros.Api.Controllers;
using Soft.Taxa.Juros.Domain.TaxaJuro;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Taxa.Juros.TestesUnitarios.Api.Controllers
{
    [TestFixture]
    public class TaxaJurosControllerTests
    {
        private Mock<IMediator> _mockMediator;
        private TaxaJurosController _controller;

        [SetUp]
        public void Setup()
        {
            _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
            _controller = new TaxaJurosController(_mockMediator.Object);
        }

        [Test]
        public void Deve_VerificarAtributos_Quando_BuscarTaxaDeJuros()
        {
            //Assert
            typeof(TaxaJurosController)
               .GetMethod(nameof(TaxaJurosController.ObterTaxaDeJuros))
               .Should()
               .BeDecoratedWith<HttpGetAttribute>();
        }

        [Test]
        public async Task Deve_RetornarOk_Quando_BuscarTaxaDeJuros()
        {
            //Arrange
            var query = new TaxaJuroQuery();

            _mockMediator
                .Setup(p => p.Send(It.IsAny<TaxaJuroQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(decimal));

            // Act
            var result = await _controller.ObterTaxaDeJuros();

            // Assert
            var response = result.Should().BeOfType<OkObjectResult>().Subject.Value;
            response.Should().BeOfType<decimal>();

            _mockMediator.Verify(p => p.Send(It.IsAny<TaxaJuroQuery>(), It.IsAny<CancellationToken>()));
        }
    }
}
