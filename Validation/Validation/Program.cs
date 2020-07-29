using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario = new UsuarioForm()
            {
                Salario = 4599,
                Email = "r"
            };

            var listaMensagens = new List<ValidationResult>();
            var contexto = new ValidationContext(usuario);
            bool isValid = Validator.TryValidateObject(usuario, contexto, listaMensagens, true);

            listaMensagens.ForEach(m => Console.WriteLine(m));
        }
    }
}
