using Microsoft.EntityFrameworkCore;
using SistemaPub.Models;

namespace SistemaPub.Database
{
    public class PubContext:DbContext
    {
        public PubContext(DbContextOptions<PubContext> options):base(options)
        {

        }


       public DbSet<Cliente> Clientes { get; set; }
       public DbSet<Produto> Produtos { get; set; }

    }
}
