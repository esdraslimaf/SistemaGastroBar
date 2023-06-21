using Microsoft.EntityFrameworkCore;
using SistemaPub.Models;

namespace SistemaPub.Database
{
    public class PubContext:DbContext
    {
        public PubContext(DbContextOptions<PubContext> options):base(options)
        {

        }

       public DbSet<Produto> Produtos { get; set; }
       public DbSet<Comanda> Comandas { get; set; }
       public DbSet<ProdutoComanda> ProdutosComandas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Comanda>().Property(c=>c.ValorComanda).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Produto>()
       .HasData(
           // Petiscos
           new Produto { Id = 1, Nome = "Espeto de Porco", Preco = 7.00m },
           new Produto { Id = 2, Nome = "Espeto de Frango com Bacon", Preco = 8.00m },
           new Produto { Id = 3, Nome = "Coxinha de Frango", Preco = 7.00m },
           new Produto { Id = 4, Nome = "Batata Frita", Preco = 14.00m },
           // Cervejas
           new Produto { Id = 5, Nome = "Itaipava 600 ml", Preco = 7.50m },
           new Produto { Id = 6, Nome = "Budweiser", Preco = 10.00m },
           new Produto { Id = 7, Nome = "Heineken", Preco = 17.00m },
           new Produto { Id = 8, Nome = "Spaten", Preco = 12.00m },
           // Doses
           new Produto { Id = 9, Nome = "Dose de Ypioca Ouro", Preco = 4.00m },
           new Produto { Id = 10, Nome = "Dose de 51", Preco = 4.00m },
           new Produto { Id = 11, Nome = "Dose de Jack Daniel's", Preco = 14m }
       );
        }

    }
}
