using Microsoft.EntityFrameworkCore;
using BarControl.Model;
namespace BarControl.Data;

public class BarControlContext : DbContext
{
    public DbSet<BarControl.Model.Waiter> Waiter { get; set; } = default!; // BarControl.Model.Waiter is basically the Waiter Class. The DbSet is basically a list? 
    public DbSet<BarControl.Model.Client> Client { get; set; } = default!;
    public DbSet<BarControl.Model.Table> Table { get; set; } = default!;
    public DbSet<BarControl.Model.Consumption> Consumption { get; set; } = default!;
    public DbSet<BarControl.Model.Slip> Slip { get; set; } = default!;
    public DbSet<BarControl.Model.Product> Product { get; set; } = default!;
    public DbSet<BarControl.Model.BaseModel> BaseModel { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseInMemoryDatabase("BarControl");
     
        // ConnectionString
        optionsBuilder.UseSqlServer("Server=localhost, 1433;Database=BarControl;User Id=sa;Password=SimplePass123;TrustServerCertificate=True");
        // Logging on the console
        optionsBuilder.LogTo(Console.WriteLine); 
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseModel>();

        // Configure inheritance with TPH
        modelBuilder.Entity<Client>().ToTable("Client");
        modelBuilder.Entity<Consumption>().ToTable("Consumption");
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Slip>().ToTable("Slip");
        modelBuilder.Entity<Table>().ToTable("Table");
        modelBuilder.Entity<Waiter>().ToTable("Waiter");

        modelBuilder.Entity<Consumption>()
            .HasOne(c => c.Product)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Consumption>()
            .HasOne(c => c.Slip)
            .WithMany(s => s.Consumptions)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Slip>()
            .HasOne(s => s.Client)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Slip>()
            .HasOne(s => s.Table)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Slip>()
            .HasOne(s => s.Waiter)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
    
    public void Seed()
    {
        if (Database.EnsureCreated())
        {
            WaiterSeed();
            ClientSeed();
            TableSeed();
            ProductSeed();
            SlipSeed();
        }
    }
    
    private void ClientSeed()
    {
        if (Client.Any() is false)
        {
            for (int i = 0; i < 10; i++)
            {
                Client client = new Client();
                client.Name = "Cliente " + i.ToString();
                Client.Add(client);
            }

            SaveChanges();
        }
    }

    private void WaiterSeed()
    {
        if (Waiter.Any() is false)
        {
            for (int i = 0; i < 5; i++)
            {
                Waiter waiter = new Waiter()
                {
                    Name = "Waiter " + i,
                    Age = 18 + i
                };
                Waiter.Add(waiter);
                SaveChanges();

            }
        }
    }

    private void TableSeed()
    {
        if (Table.Any() is false)
        {
            for (int i = 0; i < 5; i++)
            {
                Table table = new Table()
                {
                    Number = (i + 1)
                };
                Table.Add(table);
                SaveChanges();

            }
        }
    }

    private void ProductSeed()
    {
        if (Product.Any() is false)
        {
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product()
                {
                    Name = "Product " + i,
                    Description = "Description for product " + i,
                    PurchasePrice = 10.0 + i,
                    SellingValue = 20.0 + i
                };
                Product.Add(product);
                SaveChanges();

            }
        }
    }

        private void SlipSeed()
        {
            // Ensure Clients, Tables, and Waiters are already seeded
            if (Client.Any() && Table.Any() && Waiter.Any() && Slip.Any() is false)
            {
                Slip slip = new Slip();
                slip.OpeningDate = DateTime.Now;

                // Get the first available client
                Client client = Client.FirstOrDefault();
                if (client != null)
                {
                    slip.Client = client;
                    slip.ClientId = client.Id;
                }

                // Get the first available table
                Table table = Table.FirstOrDefault();
                if (table != null)
                {
                    slip.Table = table;
                    slip.TableId = table.Id;
                }

                // Get the first available waiter
                Waiter waiter = Waiter.FirstOrDefault();
                if (waiter != null)
                {
                    slip.Waiter = waiter;
                    slip.WaiterId = waiter.Id;
                }

                Slip.Add(slip);
                SaveChanges();

                // Ensure a product is available before creating consumption
                Product product = Product.FirstOrDefault();
                if (product != null)
                {
                    Consumption consumption = new Consumption
                    {
                        Product = product,
                        ProductId = product.Id,
                        Slip = slip,
                        SlipId = slip.Id,
                        Amount = 1
                    };

                    Consumption.Add(consumption);
                    SaveChanges();
                }
            }
        }

    }


















