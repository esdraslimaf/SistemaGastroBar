using SistemaPub.Models;

namespace SistemaPub.Repository.Interfaces
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> BuscarTodosProdutos();
        Task<Produto> BuscarProdutosPorId(int id);
        void AdicionarProduto(Produto produto);
        void RemoverProduto(int id);
        void AtualizarProduto(Produto produto);
    }
}
