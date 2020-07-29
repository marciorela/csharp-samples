using System;
using System.ComponentModel.DataAnnotations;

namespace Validation
{
    public class UsuarioForm
    {
        [Required(ErrorMessage = "Nome deve ser informado.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Range(2000, 8000, ErrorMessage = "Valor de salário fora da faixa")]
        public double Salario { get; set; }
    }
}
