using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPub.Models;
using SistemaPub.Repository;

namespace SistemaPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repo;
        public ClienteController(IClienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCliente(int id)
        {
            Cliente cliente = await _repo.BuscarClientePorId(id);
            if (cliente == null) return BadRequest("Cliente não encontrado!");
            return Ok("Cliente selecionado: "+cliente);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosClientes()
        {
            List<Cliente> Clientes = await _repo.BuscarTodosClientes();
            if (Clientes.Count == 0) return Ok("A lista ainda não possui clientes");
            return Ok(Clientes);
        }

        [HttpPost]
        public IActionResult AddCliente([FromBody] Cliente cliente)
        {
            _repo.AdicionarCliente(cliente);
            return Ok($"Usuário de {cliente.Id} id adicionado!");
        }

        [HttpDelete]
        public IActionResult RemoveCliente(int id)
        {
            _repo.RemoveCliente(id);
            return Ok("Removido!");
        }

    }
}
