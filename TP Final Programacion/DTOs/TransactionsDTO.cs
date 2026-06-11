namespace TP_Final_Programacion.DTOs
{
    public class TransactionsDTO
    {
        public int Id { get; set; }
        public string CodigoCriptomoneda { get; set; }
        public string Accion { get; set; }
        public int ClienteId { get; set; }
        public decimal CryptoAmount { get; set; }
        public decimal Moneda { get; set; }
        public DateTime Fecha { get; set; }

        public ClienteDTO? Cliente { get; set;}
        public CriptomonedaDTO? Criptomoneda { get; set; }
    }
}
