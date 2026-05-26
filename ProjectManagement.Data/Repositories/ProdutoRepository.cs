using ProjectManagement.Domain;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Interfaces;


namespace ProjectManagement.Data.Repositories
{
    public class ProdutoRepository:IProductRepository
    {
        private List<Produto> _produtos; //convenção para quando o atributo é privado (iniciar com underscore)
        private int _proximoId;

        public ProdutoRepository()
        {
            _produtos = new List<Produto>();
            _proximoId = 1;
        }

        public void Adicionar(Produto produto)
        {
            produto.Id = _proximoId;
            _proximoId++;

            _produtos.Add(produto);

        }

        public List<Produto> ObterTodos()
        {
            return _produtos;
        }

        public Produto? ObterPorNome(string nome)
        {
            foreach (Produto p in _produtos)
            {
                if (p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    return p;
                }
            }
            return null;
        }

    }
}
