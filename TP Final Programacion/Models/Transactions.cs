using System.ComponentModel.DataAnnotations.Schema;

namespace TP_Final_Programacion.Models
{
    public class Transactions
    {
        public int Id { get; set; }
        public string codigoCriptomoneda { get; set; }
        public string accion { get; set; }
        public int ClienteId { get; set; }
        [Column(TypeName = "decimal(18,8)")]
        public decimal CryptoAmount { get; set; }
        [Column(TypeName = "decimal(18,8)")]
        public decimal Moneda { get; set; }
        public DateTime fecha { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
