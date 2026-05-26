using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace ProductManagement.Business.Services
{
    public class ProductService
    {// regras de negócio

        private readonly IProductRepository _repositorio;

        //readonly não permite alteração depois de inicializada

        // Declarar um campo privado da classe que guarda referencia a um repositorio ,
        // e essa ref so pode ser atribuida no construtor ou na propria declaração

        public ProductService(IProductRepository repositorio)
        {
            _repositorio = repositorio;
        }

        // injeção de dependencia: Esta classe não cria o repositório, vai ser injetado aqui, através de inicialização new

        public void AdicionarProduto(string nome, decimal preco)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("O nome não pode ser vazio");
            }

            if (preco<=0)
            {
                throw new Exception("O preço deve ser maior que zero");
            }

            Produto novo = new Produto();
            novo.Nome = nome;
            novo.Preco = preco;

            _repositorio.Adicionar(novo);

            // A camada de negocio delega (prepara) acesso a camada de dados

        }

        public List<Produto> ListarTodos()
        {
            return _repositorio.ObterTodos();
        }

        public Produto? ProcurarProduto(string nome)
        {
            return _repositorio.ObterPorNome(nome);
        }

    }
}
