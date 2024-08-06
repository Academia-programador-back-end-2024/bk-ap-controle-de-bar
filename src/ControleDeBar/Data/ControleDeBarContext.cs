using ControleDeBar.Model;
using Microsoft.EntityFrameworkCore;

namespace ControleDeBar.Data
{
    public class ControleDeBarContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ControleBar");
        }
        public DbSet<ControleDeBar.Model.Garcon> Garcon { get; set; } = default!;

    }
}
