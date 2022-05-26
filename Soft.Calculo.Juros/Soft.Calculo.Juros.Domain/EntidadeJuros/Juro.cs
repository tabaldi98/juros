using System;

namespace Soft.Calculo.Juros.Domain.EntidadeJuros
{
    public class Juro
    {
        public decimal ValorInicial { get; private set; }
        public decimal TaxaJuros { get; private set; }
        public int Meses { get; private set; }

        public Juro(decimal valorInicial, decimal taxaJuros, int meses)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;
            Meses = meses;
        }

        public double CalcularJuros()
        {
            var taxaJuros = TaxaJuros + 1;

            return Math.Pow(decimal.ToDouble(ValorInicial * taxaJuros), Meses);
        }
    }
}
