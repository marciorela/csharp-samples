using System;
using System.Globalization;
using System.Text.Encodings.Web;

namespace CalculoTroco
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] moedas = { 100, 50, 10, 1, 0.50f, 0.25f, 0.10f, 0.01f };

            Console.WriteLine("Informe o valor da venda: ");
            var venda = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Valor que o cliente forneceu: ");
            var valorCliente = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var troco = Math.Round(valorCliente - venda, 2);
            foreach (var moeda in moedas)
            {
                var notas = (int)(troco / moeda);
                if (notas > 0)
                {
                    troco -= Math.Round(notas * moeda, 2);
                    Console.WriteLine($"Devolver ({moeda} x {notas}): {moeda * notas}");
                }
            }
        }
    }
}