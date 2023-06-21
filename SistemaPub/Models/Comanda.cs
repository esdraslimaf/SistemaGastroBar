namespace SistemaPub.Models
{
    public class Comanda
    {
        public int Id { get; set; }
        public string? IdentificaCliente { get; set; }
        public DateTime DataComandaAbriu { get; set; } = DateTime.Now;
        public DateTime? DataComandaFechada { get; set; }
        public int Ativa { get; set; } = 1;
        public decimal? ValorComanda { get; set; } = 0;
        public List<ProdutoComanda>? ProdutosComanda { get; set; }

        public Comanda()
        {

        }

       /* public decimal ValorTotalComanda()
        {
            decimal total = 0;
            foreach (var prod in this.ProdutosComanda)
            {
                total += prod.Produto.Preco;
            }
            return total;
        }
       */
      
    }
}
