using System.ComponentModel.DataAnnotations;

namespace TP_Final_Programacion.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }

        public List<Transactions> Transactions { get; set; } = new();
    }
}
