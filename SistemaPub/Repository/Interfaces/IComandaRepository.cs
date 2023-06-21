using SistemaPub.Models;

namespace SistemaPub.Repository.Interfaces
{
    public interface IComandaRepository
    {
        Task<List<Comanda>> BuscarTodasComandasAtivas();
        Task<Comanda> AdicionarNovaComanda(Comanda Comanda);
        Task<Comanda> FecharComanda(int id);
        //Task<Comanda> ConsultarComanda(int id);
   

    }
}
