using ControleDeBar.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Data
{
    public class ControleDeBarContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Garcom> Garcom { get; set; } = default!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ControleBar");
        }
        public DbSet<ControleDeBar.Model.Mesa> Mesa { get; set; } = default!;

    }
}
