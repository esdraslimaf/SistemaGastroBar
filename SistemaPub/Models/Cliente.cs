namespace SistemaPub.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Comanda Comanda { get; set; }
        public DateTime Horario { get; set; } = DateTime.Now;

        public Cliente()
        {

        }

        public Cliente(int id, string nome, DateTime horario)
        {
            Id = id;
            Nome = nome;
            Horario = horario;
        }

    }
}
