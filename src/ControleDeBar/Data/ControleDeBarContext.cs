using ControleDeBar.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Data
{
    public class ControleDeBarContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Garcom> Garcom { get; set; } = default!;
        public DbSet<Mesa> Mesa { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Consumo> Consumos { get; set; } = default!;
        public DbSet<Comanda> Comandas { get; set; } = default!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ControleBar");
        }
    }
}
