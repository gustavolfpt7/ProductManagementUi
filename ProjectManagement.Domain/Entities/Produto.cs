namespace ProjectManagement.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto()
        {
            Nome = string.Empty; //Definir como vazio para evitar NULL
        }
    }
}
