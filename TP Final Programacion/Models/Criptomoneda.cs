using System.ComponentModel.DataAnnotations;

namespace TP_Final_Programacion.Models
{
    public class Criptomoneda
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
    }
}
