using CSVExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Threading;

namespace CarregarCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            CarregarArquivoCSV(@"C:\Users\mrela\Downloads\Protocolo_Varas\de-para-varas-bacen-cnj.csv");
            CarregarArquivoPosicional(@"\\jd\Arquivos\Sistemas\JD Sistema Ocorrencias\Evidencias\JD-13\JD-13469\Suporte\Arquivos 5305 Desde 08092020\BJ2VJ1823612020200909231200.TXT");
        }

        static void CarregarArquivoCSV(string fileName)
        {
            using var sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();

                var vara = s.FromCSV<Vara>();

                try
                {
                    if (vara.Cod_bacen == "18466")
                    {
                        Console.WriteLine(vara.Cod_bacen);
                        Console.WriteLine(vara.Vara_bacen);
                        Console.WriteLine(vara.Tribunal_bacen);
                        Console.WriteLine(vara.Cod_orgao_cnj);
                        Console.WriteLine(vara.Orgao_cnj);
                        Console.WriteLine(vara.Percentual_similar);
                        Console.WriteLine("=====================");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(s);
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }

        }

        static void CarregarArquivoPosicional(string fileName)
        {
            using var sr = new StreamReader(fileName);

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();

                var vara = s.FromPositional<OutraVara>();

                try
                {
                    if (vara.TpRegistro == "02")
                    {
                        Console.WriteLine(vara.Codigo);
                        Console.WriteLine("=====================");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(s);
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }

        }

    }

    public class Vara
    {
        public string Cod_bacen { get; set; }
        public string Vara_bacen { get; set; }
        public string Tribunal_bacen { get; set; }
        public string Cod_orgao_cnj { get; set; }
        public string Orgao_cnj { get; set; }
        public string Percentual_similar { get; set; }

    }

    public class OutraVara
    {
        [Positional(1, 2)]
        public string TpRegistro { get; set; }
        
        [Positional(3, 5)]
        public string Codigo { get; set; }

        [Positional(123, 215)]
        public string Tribunal { get; set; }
    }

}
