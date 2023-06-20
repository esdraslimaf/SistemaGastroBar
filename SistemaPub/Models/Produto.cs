namespace SistemaPub.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int? Estoque { get; set; }
        public List<ProdutoComanda> ProdutosComanda { get; set; }
    }
}
