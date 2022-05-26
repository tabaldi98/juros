namespace Soft.Calculo.Juros.Infra.Extensoes
{
    public static class DecimalExtensoes
    {
        public static string FormatarCasasDecimais(this decimal valor, int quantidadeCasasDecimais = 2)
        {
            var formato = "0";
            for (int i = 1; i < quantidadeCasasDecimais; i++) formato += "0";

            return valor.ToString($"0.{formato}");
        }
    }
}
