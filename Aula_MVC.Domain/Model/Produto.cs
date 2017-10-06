using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Data.Domain;
using Aula_MVC.Data.Helpers;

namespace Aula_MVC.Domain.Model
{
    public class Produto : IEntity
    {
        public virtual long Id { get; set; }


        public string Nome { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }

      
        public Produto(string nome, Categoria categoria, decimal preco, int quantidadeEstoque)
        {
            ValidateValues(nome, categoria, preco, quantidadeEstoque);
        }
        private static void ValidateValues(string nome, Categoria categoria, decimal preco, int quantidadeEstoque)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome Obrigatório");
            DomainException.When(categoria == null, "Categoria Obrigatório");
            DomainException.When(preco < 0, "Preço Obrigatório");
            DomainException.When(quantidadeEstoque < 0, "Quantidade em estoque Obrigatório");
        }
        public void RemoveFromStock(int quantity)
        {
            DomainException.When((QuantidadeEstoque - quantity) < 0, "Quantidade solicitado não tem em estoque !");
            QuantidadeEstoque -= quantity;
        }

    }
}
