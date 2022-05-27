using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Soft.Calculo.Juros.Api.Controllers;
using Soft.Calculo.Juros.Domain.EntidadeMeuCodigo;
using System.Threading;
using System.Threading.Tasks;

namespace Soft.Calculo.Juros.TestesUnitarios.Api.Controllers
{
    [TestFixture]
    public class ShowMeTheCodeControllerTests
    {
        private Mock<IMediator> _mockMediator;
        private ShowMeTheCodeController _controller;

        [SetUp]
        public void Setup()
        {
            _mockMediator = new Mock<IMediator>(MockBehavior.Strict);
            _controller = new ShowMeTheCodeController(_mockMediator.Object);
        }

        [Test]
        public void Deve_VerificarAtributos_Quando_BuscarLinkDoProjetoNoGitHub()
        {
            //Assert
            typeof(ShowMeTheCodeController)
               .GetMethod(nameof(ShowMeTheCodeController.BuscarLinkDoProjetoNoGitHub))
               .Should()
               .BeDecoratedWith<HttpGetAttribute>();
        }

        [Test]
        public async Task Deve_RetornarOk_Quando_BuscarLinkDoProjetoNoGitHub()
        {
            //Arrange
            _mockMediator
                .Setup(p => p.Send(It.IsAny<MeuCodigoQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("mock-url");

            // Act
            var result = await _controller.BuscarLinkDoProjetoNoGitHub();

            // Assert
            var response = result.Should().BeOfType<OkObjectResult>().Subject.Value;
            response.Should().BeOfType<string>();

            _mockMediator.Verify(p => p.Send(It.IsAny<MeuCodigoQuery>(), It.IsAny<CancellationToken>()));
        }
    }
}
