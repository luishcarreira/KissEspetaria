using System;
using System.ComponentModel.DataAnnotations;

namespace Inter_KissEspataria.Models
{
    public class PessoaGarcon : Pessoa
    {
        [Display(Name = "Valor p/ Dia")]
        [Required(ErrorMessage = "Campo 'Valor p/ Dia' obrigatório!")]
        public Decimal Comissao { get; set; }
        public String RegimeTrab { get; set; }

        public String Ativo { get; set; }
    }
}