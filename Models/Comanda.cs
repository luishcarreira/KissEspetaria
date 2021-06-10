using System.Linq;
using System.Collections.Generic;

namespace Inter_KissEspataria.Models
{
    public class Comanda
    {
        public int? PedidoId { get; set; }
        public int? AtendenteId { get; set; }
        public int? GarconId { get; set; }
        public char Status { get; set; }
        public string Observacao { get; set; }
        public List<Item> Itens { get; set; } = new List<Item>();

        public decimal valorTotal
        {
            get
            {
                return Itens.Sum(i => i.ValorTotal);
            }
        }
    }
}