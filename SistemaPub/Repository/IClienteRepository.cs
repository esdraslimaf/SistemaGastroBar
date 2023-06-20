using SistemaPub.Models;

namespace SistemaPub.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> BuscarTodosClientes();
        Task<Cliente> BuscarClientePorId(int id);
        void AdicionarCliente(Cliente cliente);
        void RemoveCliente(int id);
        void AtualizarCliente(int id);
    }
}
