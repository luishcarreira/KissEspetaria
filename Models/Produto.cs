namespace Inter_KissEspataria.Models
{
    public class Produto
    {
        public int? ProdutoId { get; set; }
        public string Descricao { get; set; }
        public char Status { get; set; }
        public int QtdEstoque { get; set; }
        public decimal Valor { get; set; }
    }
}