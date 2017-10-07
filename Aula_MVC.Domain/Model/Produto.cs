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


        public virtual string Nome { get;  set; }
        public virtual Categoria Categoria { get;  set; }
        public virtual decimal Preco { get;  set; }
        public virtual int QuantidadeEstoque { get;  set; }


        //protected Produto(string nome, Categoria categoria, decimal preco, int quantidadeEstoque)
        //{
        //    ValidateValues(nome, categoria, preco, quantidadeEstoque);
        //}
        //protected static void ValidateValues(string nome, Categoria categoria, decimal preco, int quantidadeEstoque)
        //{
        //    DomainException.When(string.IsNullOrEmpty(nome), "Nome Obrigatório");
        //    DomainException.When(categoria == null, "Categoria Obrigatório");
        //    DomainException.When(preco < 0, "Preço Obrigatório");
        //    DomainException.When(quantidadeEstoque < 0, "Quantidade em estoque Obrigatório");
        //}
        //protected void RemoveFromStock(int quantity)
        //{
        //    DomainException.When((QuantidadeEstoque - quantity) < 0, "Quantidade solicitado não tem em estoque !");
        //    QuantidadeEstoque -= quantity;
        //}

    }
}
