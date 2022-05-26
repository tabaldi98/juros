using System.Threading.Tasks;

namespace Soft.Calculo.Juros.Domain.EntidadeJuros
{
    public interface IJuroRepositorio
    {
        Task<decimal> BuscarTaxaDeJuro();
    }
}
