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
            //optionsBuilder.UseInMemoryDatabase("ControleBar");

            //COnnectionString => 
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=CONTROLE_DE_BAR;User Id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;");

            optionsBuilder.LogTo(Console.WriteLine);
        }

        public void Semear()
        {
            if (this.Database.EnsureCreated())//DDL
            {
                SemearGarcom();
                SemearCLientes();
                SemearMesas();
                SemearProduto();
                SemearComanda();
            }
        }

        private void SemearCLientes()
        {
            if (Clientes.Any() is false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Cliente cliente = new Cliente();
                    cliente.Nome = "Cliente " + i.ToString();
                    cliente.Id = i.ToString();
                    Clientes.Add(cliente);
                }

                SaveChanges();
            }
        }

        private void SemearGarcom()
        {
            if (Garcom.Any() is false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Garcom garcom = new Garcom();
                    garcom.Nome = $"Garçom {i}";
                    garcom.Id = i.ToString();
                    Garcom.Add(garcom);
                }

                SaveChanges();
            }
        }

        private void SemearMesas()
        {
            if (Mesa.Any() is false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Mesa mesa = new Mesa();
                    mesa.Numero = i + 1;
                    mesa.Id = i.ToString();
                    Mesa.Add(mesa);
                }

                SaveChanges();
            }
        }

        private void SemearProduto()
        {
            if (Produto.Any() is false)
            {
                for (int i = 0; i < 10; i++)
                {
                    Produto produto = new Produto();
                    produto.Nome = $"Produto {i}";
                    produto.Descricao = "Produto de exemplo";
                    produto.PrecoDeCompra = 1 + i;
                    produto.PrecoDeVenda = 2 + i;
                    produto.Id = i.ToString();
                    Produto.Add(produto);
                }

                SaveChanges();
            }
        }

        private void SemearComanda()
        {
            if (Comandas.Any() is false)
            {
                Comanda comanda = new Comanda();
                comanda.DataDeAbertura = DateTime.Now;


                Cliente cliente = Clientes.FirstOrDefault();

                comanda.Cliente = cliente;
                comanda.ClienteId = cliente.Id;

                Mesa mesa = Mesa.FirstOrDefault();

                comanda.Mesa = mesa;
                comanda.MesaId = mesa.Id;

                Garcom garcom = Garcom.FirstOrDefault();

                comanda.Garcom = garcom;
                comanda.GarcomId = garcom.Id;

                Comandas.Add(comanda);


                SaveChanges();

                Consumo consumo = new Consumo();

                consumo.Produto = Produto.FirstOrDefault();
                consumo.ProdutoId = consumo.Produto.Id;

                consumo.Comanda = comanda;
                consumo.ComandaId = comanda.Id;

                consumo.Quantidade = 1;
                Consumos.Add(consumo);
                SaveChanges();


            }
        }

    }
}
