using Microsoft.EntityFrameworkCore;
using SistemaPub.Database;
using SistemaPub.Models;
using SistemaPub.Repository.Interfaces;

namespace SistemaPub.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PubContext _db;
        public ProdutoRepository(PubContext db)
        {
            _db = db;
        }
        public void AdicionarProduto(Produto produto)
        {
            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }
       
        public async Task<Produto> BuscarProdutosPorId(int id)
        {
           return await _db.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _db.Produtos.ToListAsync();
        }

        public void AtualizarProduto(Produto produto)
        {
            var produtoBuscado = _db.Produtos.Find(produto.Id);
            if (produto == null) throw new Exception("Produto não encontrado!");
            else
            {
                produtoBuscado.Nome = produto.Nome;
                produtoBuscado.Preco = produto.Preco;
                produtoBuscado.Estoque = produto.Estoque;
                _db.Update(produtoBuscado);
                _db.SaveChanges();
            }
        }

        public void RemoverProduto(int id)
        {
            _db.Produtos.Remove(_db.Produtos.Find(id));
            _db.SaveChanges();
        }
    }
}
