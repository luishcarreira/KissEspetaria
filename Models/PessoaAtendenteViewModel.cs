using System;
using System.ComponentModel.DataAnnotations;

namespace Inter_KissEspataria.Models.ViewModel
{
    public class PessoaAtendenteViewModel : Pessoa
    {
        [Required(ErrorMessage = "Campo 'Login' obrigatório!")]
        public String Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo 'Senha' obrigatório!")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public String Senha { get; set; }
    }
}