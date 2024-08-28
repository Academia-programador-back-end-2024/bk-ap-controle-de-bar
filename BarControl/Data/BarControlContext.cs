using Microsoft.EntityFrameworkCore;
using BarControl.Model;
namespace BarControl.Data;

public class BarControlContext : DbContext
{
    public DbSet<Client> clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("BarControl");
    }

public DbSet<BarControl.Model.Waiter> Waiter { get; set; } = default!;
public DbSet<BarControl.Model.Table> Table { get; set; } = default!;

public DbSet<BarControl.Model.Product> Products { get; set; } = default!;
public DbSet<BarControl.Model.BaseModel> BaseModel { get; set; } = default!;
}