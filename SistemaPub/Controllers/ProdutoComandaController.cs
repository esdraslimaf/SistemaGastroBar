using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPub.Models;
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
        /// <summary>
        /// Método para cadastrar um pedido de um determinado cliente
        /// </summary>
        /// <param name="IdComanda"></param>
        /// <param name="IdProduto"></param>
        /// <returns></returns>
        [HttpPost("{IdComanda}/{IdProduto}")]
        public IActionResult NovoPedido(int IdComanda, int IdProduto)
        {
           int idpedido = _repo.NovoPedido(IdComanda, IdProduto);
            Produto produto = _repo.RetornaProduto(IdProduto);
            Comanda comanda = _repo.RetornaComanda(IdComanda);
            
            return Ok($"{produto.Nome} ${produto.Preco} foi acrescentado na comanda: {comanda.IdentificaCliente}({comanda.Id}) - ID DO PEDIDO: ({idpedido})");
        }
        /// <summary>
        /// Remove um determinado pedido de um cliente
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        [HttpDelete("RemoverPedidoCliente")]
        public IActionResult RemoverPedido(int IdPedido)
        {
            _repo.RemoverPedido(IdPedido);
            return Ok("Removido!");
        }
        /// <summary>
        /// Busca todos os pedidos realizados
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarTodosPedidosClientes")]
        public IActionResult BuscarPedidosClientes()
        {
            return Ok(_repo.BuscarPedidosClientes());
        }
        /// <summary>
        /// Busca informações dos pedidos de um único cliente(Passe o ID do cliente)
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuscarPedidosUnicoCliente{id}")]
        public IActionResult BuscarPedidosClienteId(int id)
        {
            return Ok(_repo.BuscarPedidosClienteId(id));
        }
    }
}
