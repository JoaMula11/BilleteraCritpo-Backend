using Microsoft.EntityFrameworkCore;

namespace TP_Final_Programacion.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Criptomoneda> Criptomonedas { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Criptomoneda>()
                .Property(c => c.Precio)
                .HasColumnType("decimal(18,4)"); // 18 dígitos en total, 4 decimales (o los que necesites)

        }
    }
}
