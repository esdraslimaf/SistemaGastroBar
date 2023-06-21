using Microsoft.EntityFrameworkCore;
using SistemaPub.Database;
using SistemaPub.Models;
using SistemaPub.Repository.Interfaces;
using System.Text;

namespace SistemaPub.Repository
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly PubContext _db;
        public ComandaRepository(PubContext db)
        {
            _db = db;
        }

        public async Task<List<Comanda>> BuscarTodasComandasAtivas()
        {
            return await _db.Comandas.Where(c => c.Ativa == 1).ToListAsync();
            //.ToListAsync();
        }



        public async Task<Comanda> AdicionarNovaComanda(Comanda comanda)
        {
            _db.Comandas.Add(comanda);
            await _db.SaveChangesAsync();
            return comanda;
        }

        public async Task<Comanda> FecharComanda(int id)
        {
            Comanda comanda = await _db.Comandas.Include(c=>c.ProdutosComanda).ThenInclude(p=>p.Produto).FirstOrDefaultAsync(c => c.Id == id);
            comanda.Ativa = 0;
            comanda.DataComandaFechada = DateTime.Now;
            decimal valor = 0;
            if (comanda.ProdutosComanda != null)
            {
                foreach(ProdutoComanda prod in comanda.ProdutosComanda)
                {
                    valor += prod.Produto.Preco;
                }
            }
            comanda.ValorComanda = valor;
            _db.Update(comanda);
            await _db.SaveChangesAsync();
            return comanda;
        }
    }
}
