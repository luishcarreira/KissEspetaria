using System.ComponentModel.DataAnnotations;

namespace Inter_KissEspataria.Models
{
    public class Produto
    {
        public int? ProdutoId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo 'Descrição' obrigatório!")]
        public string Descricao { get; set; }
        public char Status { get; set; }

        [Display(Name = "Quantidade em estoque")]
        [Required(ErrorMessage = "Campo 'Quantidade em estoque' obrigatório!")]
        public int QtdEstoque { get; set; }
        public decimal Valor { get; set; }
    }
}