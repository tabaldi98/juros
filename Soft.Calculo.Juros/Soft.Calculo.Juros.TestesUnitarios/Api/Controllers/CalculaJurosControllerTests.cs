using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Soft.Calculo.Juros.Api.Controllers;
using Soft.Calculo.Juros.Domain.EntidadeJuros.CalculaJuros;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.TestesUnitarios.Api.Controllers
{
    [TestFixture]
    public class CalculaJurosControllerTests
    {
        private Mock<IMediator> _mockMediator;
        private CalculaJurosController _controller;

        [SetUp]
        public void Setup()
        {
            _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
            _controller = new CalculaJurosController(_mockMediator.Object);
        }

        [Test]
        public void Deve_VerificarAtributos_Quando_CalcularJuros()
        {
            //Assert
            typeof(CalculaJurosController)
               .GetMethod(nameof(CalculaJurosController.CalcularJuros))
               .Should()
               .BeDecoratedWith<HttpPostAttribute>();
        }

        [Test]
        public async Task Deve_RetornarOk_Quando_CalcularJuros()
        {
            //Arrange
            var command = new CalculaJurosCommand();

            _mockMediator
                .Setup(p => p.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync("10.10");

            // Act
            var result = await _controller.CalcularJuros(command);

            // Assert
            var response = result.Should().BeOfType<OkObjectResult>().Subject.Value;
            response.Should().BeOfType<string>();

            _mockMediator.Verify(p => p.Send(command, It.IsAny<CancellationToken>()));
        }
    }
}
