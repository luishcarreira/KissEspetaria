namespace Inter_KissEspataria.Models
{
    public class Item
    {
        public int ComandaId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public Produto Produto { get; set; }

        public decimal ValorTotal
        {
            get
            {
                return Quantidade * Valor;
            }
        }

    }
}