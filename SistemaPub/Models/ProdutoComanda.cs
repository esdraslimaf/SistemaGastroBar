namespace SistemaPub.Models
{
    public class ProdutoComanda
    {
        public int Id { get; set; }
        public int ComandaId { get; set; }
        public Comanda? Comanda { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public ProdutoComanda(int comandaId, int produtoId)
        {
            ComandaId = comandaId;
            ProdutoId = produtoId;
        }

    }
}
