using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPub.Models;
using SistemaPub.Repository.Interfaces;

namespace SistemaPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repo;
        public ProdutoController(IProdutoRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Método para adicionar um novo Item/Produto/Prato à lista
        /// </summary>
        /// <param name="produto">{
        /// <para>"nome": "Batata com cheddar e bacon", "preco": 10, estoque: 4</para>
        /// <para>}</para>
        /// <para>Obs: Estoque é opcional, você pode remover este atributo caso prefira</para>
        /// </param>
        /// <returns></returns>
        [HttpPost("AdicionarItem")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            _repo.AdicionarProduto(produto);
            return Ok($"Produto {produto.Nome}(ID:{produto.Id}) - ${produto.Preco} foi adicionado ao menu!");
        }
        /// <summary>
        /// Busca todos os itens disponíveis no cardápio
        /// </summary>
        /// <returns></returns>
        [HttpGet("MenuDeItens")]
        public async Task<IActionResult> BuscarProdutos()
        {
            List<Produto> produtos = await _repo.BuscarTodosProdutos();
            return Ok(produtos);
        }

        /// <summary>
        /// Busca informações relativas a apenas um único item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProdutoPorId(int id)
        {
            Produto produto = await _repo.BuscarProdutosPorId(id);
            return Ok(produto);
        }

        /// <summary>
        /// Deleta um determinado item, produto ou prato do menu principal
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult RemoverProduto(int id)
        {
            _repo.RemoverProduto(id);
            return Ok("Produto removido!");
        }

        /// <summary>
        /// Atualiza um determinado item, produto ou prato
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult AtualizarProduto([FromBody] Produto produto)
        {
            _repo.AtualizarProduto(produto);
            return Ok("Atualizado!");
        }
    }
}
