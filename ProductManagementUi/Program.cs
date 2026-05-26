using ProjectManagement.Data.Repositories;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Entities;
using ProductManagement.Business.Services;

namespace ProductManagementUi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProdutoRepository repo = new ProdutoRepository();
            ProductService servico = new ProductService(repo);

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1 - Adicionar um Produto");
                Console.WriteLine("2 - Listar os produtos");
                Console.WriteLine("3 - Procurar por nome");
                Console.WriteLine("0 - Para sair");

                string opcao = Console.ReadLine();

                if (opcao=="1")
                {
                    Console.WriteLine("Nome: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Preco: ");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    try
                    {
                        servico.AdicionarProduto(nome, preco);
                        Console.WriteLine("Produto adicionado!");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Erro: "+ex.Message);
                    }
                }
                else if (opcao=="2")
                {
                    var lista = servico.ListarTodos();
                    foreach (var p in lista)
                    {
                        Console.WriteLine($"{p.Id} - {p.Nome} - {p.Preco}");
                    }
                }
                else if (opcao=="3")
                {
                    Console.WriteLine("Nome: ");
                    string nome = Console.ReadLine();

                    var produto = servico.ProcurarProduto(nome);

                    if (produto == null)
                    {
                        Console.WriteLine("Não encontrado");
                    }
                    else
                    {
                        Console.WriteLine($"{produto.Nome} - {produto.Id} - {produto.Preco}");
                    }
                }
                else if (opcao=="0")
                {
                    continuar = false;
                }



            }
        }
    }
}
