namespace Soft.Calculo.Juros.Infra.Extensoes
{
    public static class DoubleExtensoes
    {
        public static string FormatarCasasDecimais(this double valor, int quantidadeCasasDecimais = 2)
        {
            var formato = "0";
            for (int i = 1; i < quantidadeCasasDecimais; i++) formato += "0";

            return valor.ToString($"0.{formato}");
        }
    }
}
