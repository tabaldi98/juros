using FluentAssertions;
using NUnit.Framework;
using Soft.Calculo.Juros.Domain.EntidadeJuros;

namespace Soft.Calculo.Juros.TestesUnitarios.Domain.EntidadeJuros
{
    [TestFixture]
    public class JuroTests
    {
        [Test]
        public void Deve_VerificarPropriedades_Quando_InstanciarObjetoJuro()
        {
            // Arrange
            var valorInicial = 1;
            var taxaJuros = 2;
            var meses = 3;

            // Act
            var juro = new Juro(valorInicial, taxaJuros, meses);

            // Assert
            juro.ValorInicial.Should().Be(valorInicial);
            juro.TaxaJuros.Should().Be(taxaJuros);
            juro.Meses.Should().Be(meses);
        }

        [Test]
        public void Deve_VerificarValor_Quando_CalcularOsJuros()
        {
            // Arrange
            var juro = new Juro(100, 0.01M, 5);

            // Act
            var resultado = juro.CalcularJuros();

            // Assert
            resultado.Should().Be(105.1010050100M);
        }
    }
}
