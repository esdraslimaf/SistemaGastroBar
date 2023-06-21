using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPub.Repository.Interfaces;

namespace SistemaPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoComandaController : ControllerBase
    {
        private readonly IComandaProdutoRepository _repo;
        public ProdutoComandaController(IComandaProdutoRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("{IdComanda}/{IdProduto}")]
        public IActionResult NovoPedido(int IdComanda, int IdProduto)
        {
            _repo.NovoPedido(IdComanda, IdProduto);
            return Ok($"Produto adicionado");
        }

        [HttpGet]
        public IActionResult BuscarPedidosClientes()
        {
            return Ok(_repo.BuscarPedidosClientes());
        }
    }
}
