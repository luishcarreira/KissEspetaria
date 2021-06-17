using System;
using System.ComponentModel.DataAnnotations;

namespace Inter_KissEspataria.Models
{
    public class Pessoa
    {
        public int? PessoaId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo 'Nome' obrigatório!")]
        [MinLength(3)]
        public String Nome { get; set; }
        public String CPF { get; set; }
        public String Telefone { get; set; }
        public decimal Salario { get; set; }
    }
}