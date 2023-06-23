using SistemaPub.Models;

namespace SistemaPub.Repository.Interfaces
{
    public interface IComandaProdutoRepository
    {
        int NovoPedido(int comanda, int produto);
        List<ProdutoComanda> BuscarPedidosClientes();
        void RemoverPedido(int idpedido);
        Comanda RetornaComanda(int id);
        Produto RetornaProduto(int id);
        
    }
}
