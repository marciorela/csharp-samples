using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbSetToList
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fuList = await _funcionarioService.FindAllAsync();

            foreach (var funcionario in fuList)
            {
                Console.WriteLine($"Nome: {funcionario.Nome}, Idade: {funcionario.Idade}");
            }

            // return View(fuList)
        }
    }

    internal class _funcionarioService
    {
        internal static async Task<IEnumerable<FuncionarioViewModel>> FindAllAsync()
        {
            var fuList = _funcionarioRepository.FindAllAsync();

            var vm = fuList.Select(f => new FuncionarioViewModel()
            {
                Nome = f.Nome,
                Idade = FuncaoQueCalculaAIdade(f.Nascimento)
            });

            return vm;
        }

        private static int FuncaoQueCalculaAIdade(DateTime nascimento)
        {
            return DateTime.Now.Year - nascimento.Year;
        }
    }

    internal class _funcionarioRepository
    {
        internal static List<Funcionario> FindAllAsync()
        {
            return new List<Funcionario>()
            {
                new Funcionario() { Nome = "Joaquim", Nascimento = new DateTime(1970, 10, 10)},
                new Funcionario() { Nome = "Mario"  , Nascimento = new DateTime(1980, 12,  5)},
            };
        }
    }

    public class Funcionario
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Cargo { get; set; }
        public DateTime Admissao { get; set; }
    }

    public class FuncionarioViewModel
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

}
