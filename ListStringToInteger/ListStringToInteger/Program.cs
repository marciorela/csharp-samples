using System;
using System.Linq;

namespace ListStringToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma sequencia numérica separada por espaços: ");

            var strList = Console.ReadLine().Split(' ');
            var intList = strList.Select(i => int.Parse(i));

            //var intList = Console.ReadLine().Split(' ').Select(i => int.Parse(i));

            Console.WriteLine(intList.Min());
            Console.WriteLine(intList.Max());
            Console.WriteLine(intList.Average());

            //Console.WriteLine(intList[0]);

            foreach (var a in intList)
            {
                Console.WriteLine(a);
            }
        }
    }
}
