namespace SistemaPub.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<ProdutoComanda> ProdutosComanda { get; set; }
    }
}
