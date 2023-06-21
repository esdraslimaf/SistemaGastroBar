using SistemaPub.Models;

namespace SistemaPub.Repository.Interfaces
{
    public interface IComandaProdutoRepository
    {
        void NovoPedido(int comanda, int produto);
        List<ProdutoComanda> BuscarPedidosClientes();
    }
}
