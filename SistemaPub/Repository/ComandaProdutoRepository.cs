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
           
            Comanda comandadb = _db.Comandas.Find(comanda);
            Produto produtodb = _db.Produtos.Find(produto);

            decimal valorNovoProduto = produtodb.Preco;

            decimal ValorComanda = comandadb.ValorComanda ?? 0;

            comandadb.ValorComanda = ValorComanda + valorNovoProduto;
       

            _db.Comandas.Update(comandadb);
            _db.SaveChanges();
        }

      /*  public void AtualizaPrecoComanda (int produtoId)
        {
            decimal preco = 0;
            var produto = _db.Produtos.Find(produtoId);
            preco = 
        } */

    }
}
