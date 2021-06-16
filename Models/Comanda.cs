using System;
using System.Linq;
using System.Collections.Generic;

namespace Inter_KissEspataria.Models
{
    public class Comanda
    {
        public int ComandaId { get; set; }

        #region Dados do Atendente
        public int? AtendenteId { get; set; }
        public string Atendente { get; set; }
        #endregion

        #region Dados do Garçon
        public int? GarconId { get; set; }
        public string Garçon { get; set; }
        #endregion

        public DateTime DataEmissao { get; set; }
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