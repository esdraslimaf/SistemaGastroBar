using Microsoft.EntityFrameworkCore;
using SistemaPub.Database;
using SistemaPub.Models;

namespace SistemaPub.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PubContext _db;
        public ClienteRepository(PubContext db)
        {
            _db = db;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _db.Clientes.Add(cliente);
            _db.SaveChanges();
        }

        public void AtualizarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> BuscarClientePorId(int id)
        {
            return await _db.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id)!;
        }

        public async Task<List<Cliente>> BuscarTodosClientes()
        {
            return await _db.Clientes.ToListAsync();
        }

        public void RemoveCliente(int id)
        {
            _db.Remove(_db.Clientes.Find(id));
            _db.SaveChanges();
        }
    }
}
