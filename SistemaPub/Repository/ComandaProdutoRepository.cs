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

        public Comanda RetornaComanda(int id)
        {
            return _db.Comandas.Find(id);
        }

        public Produto RetornaProduto(int id)
        {
            return _db.Produtos.Find(id);
        }

        public int AdicionaProdutoComanda(int idcomanda, int idproduto)
        {
            ProdutoComanda novoProdutoComanda = new ProdutoComanda(idcomanda, idproduto);
            _db.ProdutosComandas.Add(novoProdutoComanda);
            _db.SaveChanges();
            return novoProdutoComanda.Id;
        }

        public int NovoPedido(int comanda, int produto)
        {

           int valorIdPedido = AdicionaProdutoComanda(comanda, produto);
         
         //_db.ProdutosComandas.Add(new ProdutoComanda(comanda,produto));        

            /*  Comanda comandadb = _db.Comandas.Find(comanda);
              Produto produtodb = _db.Produtos.Find(produto); */

            Comanda comandadb = RetornaComanda(comanda);
            Produto produtodb = RetornaProduto(produto);

            decimal valorNovoProduto = produtodb.Preco;

            decimal ValorComanda = comandadb.ValorComanda ?? 0;

            comandadb.ValorComanda = ValorComanda + valorNovoProduto;
       

            _db.Comandas.Update(comandadb);
            _db.SaveChanges();
            return valorIdPedido;
        }

        public void RetiraPrecoComanda(Comanda comanda, decimal valor)
        {
            comanda.ValorComanda -= valor;
            _db.Comandas.Update(comanda);
            _db.SaveChanges();
   
        }

        public void RemoverPedido(int idpedido)
        {
            ProdutoComanda produtocomanda = _db.ProdutosComandas.Find(idpedido);
            Produto produtodb = RetornaProduto(produtocomanda.ProdutoId);
            Comanda comandadb = RetornaComanda(produtocomanda.ComandaId);

            RetiraPrecoComanda(comandadb, produtodb.Preco);         
            _db.ProdutosComandas.Remove(produtocomanda);
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
