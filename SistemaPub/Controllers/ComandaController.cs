using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPub.Models;
using SistemaPub.Repository.Interfaces;
using System.Text;

namespace SistemaPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaRepository _repo;
        public ComandaController(IComandaRepository repo)
        {
            _repo = repo;
        }

        [HttpPost] 
        public async Task<IActionResult> AdicionarNovaComanda([FromBody] Comanda comanda)
        {
            await _repo.AdicionarNovaComanda(comanda);
            return Ok($"A comanda para {comanda.IdentificaCliente} foi adicionada");
        }

        [HttpPost("FecharComanda/{id}")]
        public async Task<IActionResult> FecharComanda(int id)
        {
            Comanda comanda = await _repo.FecharComanda(id);
            StringBuilder sb = new StringBuilder();

            if (comanda.ProdutosComanda != null)
            {
                foreach (ProdutoComanda pc in comanda.ProdutosComanda)
                {
                    sb.AppendLine(pc.Produto.Nome);
                }
            }
            return Ok($"A comanda do cliente {comanda.IdentificaCliente} foi fechada!\n" +
                $"Relatório:\n" +
                $"{sb}\n" +
                $"Valor total:{comanda.ValorComanda}");
        }

        [HttpGet("BuscarComandasEmAberto")]
        public async Task<IActionResult> BuscarComandasEmAberto()
        {
            List<Comanda> comandasAtivas = await _repo.BuscarTodasComandasAtivas();
            return Ok(comandasAtivas);
        }

        [HttpGet("BuscarComandasFechadas")]
        public async Task<IActionResult> BuscarComandasFechadas()
        {
            List<Comanda> comandasInativas = await _repo.BuscarComandasInativas();
            return Ok(comandasInativas);
        }


    }
}
