using ProjectManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManagement.Domain.Interfaces
{
    public interface IProductRepository
    {
        //Esta interface vai servir para isolar o aceesso ao dados dalogica de negócio

        public void Adicionar(Produto produto);

        public List<Produto> ObterTodos();

        public Produto? ObterPorNome(string nome); //Nullable reference tipe "?" - Permite que seja nulo sem ativar exceção


        


    }
}
