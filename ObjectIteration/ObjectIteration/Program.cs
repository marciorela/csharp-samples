using System;
using System.Collections.Generic;

namespace ObjectIteration
{
    class Program
    {
        /// <summary>
        /// POC para um pergunta no grupo Discord em
        /// 14/08/2020
        /// Iteração em lista de objetos de tipos diferentes
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var list = new List<object>()
            {
                new TypeOne(),
                new TypeTwo(),
                new TypeThree()
            };

            foreach (var o in list)
            {
                Console.WriteLine(o.ToString());
            }
        }

        class TypeOne
        {

        }

        class TypeTwo
        {

        }

        class TypeThree
        {

        }
    }
}
