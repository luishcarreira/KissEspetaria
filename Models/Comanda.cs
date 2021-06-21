using System.Runtime.Serialization;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Garcon { get; set; }
        #endregion

        public string DataEmissao { get; set; }

        public string Status { get; set; }

        public string Observacao { get; set; }

        public List<Item> Itens { get; set; } = new List<Item>();

        public decimal valorTotal { get; set; }
    }
}

public enum Status
{

}