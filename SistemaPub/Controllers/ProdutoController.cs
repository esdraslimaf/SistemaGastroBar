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

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            _repo.AdicionarProduto(produto);
            return Ok($"Produto {produto.Nome} ${produto.Preco} foi adicionado!");
        }
        [HttpGet]
        public async Task<IActionResult> BuscarProdutos()
        {
            List<Produto> produtos = await _repo.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProdutoPorId(int id)
        {
            Produto produto = await _repo.BuscarProdutosPorId(id);
            return Ok(produto);
        }

        [HttpDelete]
        public IActionResult RemoverProduto(int id)
        {
            _repo.RemoverProduto(id);
            return Ok("Produto removido!");
        }

        [HttpPut]
        public IActionResult AtualizarProduto([FromBody] Produto produto)
        {
            _repo.AtualizarProduto(produto);
            return Ok("Atualizado!");
        }
    }
}
