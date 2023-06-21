using SistemaPub.Database;
using SistemaPub.Repository.Interfaces;
using SistemaPub.Models;

namespace SistemaPub.Repository
{
    public class ComandaProdutoRepository : IComandaProdutoRepository
    {
        private readonly PubContext _db;
        public ComandaProdutoRepository(PubContext db)
        {
            _db = db;
        }

        public List<ProdutoComanda> BuscarPedidosClientes()
        {
            return _db.ProdutosComandas.ToList();
        }

      /*  public decimal ContaTotal(int id)
        {
            var comanda = _db.Comandas.Find(id);
            return comanda.ValorTotalComanda();
        } */

        public void NovoPedido(int comanda, int produto)
        {
            _db.ProdutosComandas.Add(new ProdutoComanda(comanda,produto));        
            _db.SaveChanges();
        }

        
    }
}
