using Microsoft.EntityFrameworkCore;
using BarControl.Model;
namespace BarControl.Data;

public class BarControlContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("BarControl");
    }
public DbSet<BarControl.Model.Waiter> Waiter { get; set; } = default!; // BarControl.Model.Waiter is basically the Waiter Class. The DbSet is basically a list? 
public DbSet<BarControl.Model.Client> Client { get; set; } = default!;
public DbSet<BarControl.Model.Table> Table { get; set; } = default!;
public DbSet<BarControl.Model.Consumption> Consumption { get; set; } = default!;
public DbSet<BarControl.Model.Slip> Slip { get; set; } = default!;
public DbSet<BarControl.Model.Product> Product { get; set; } = default!;
public DbSet<BarControl.Model.BaseModel> BaseModel { get; set; } = default!;

}   