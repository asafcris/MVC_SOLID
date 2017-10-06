using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Data.Domain;
using Aula_MVC.Data.Helpers;

namespace Aula_MVC.Domain.Model
{
    public class VendaItem : IEntity
    {
        public virtual long Id { get; set; }
        public Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }

        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }

        public VendaItem(Produto produto, int quantidade)
        {
            DomainException.When(produto == null, "Produto Obrigatório");
            DomainException.When(quantidade < 1, "Quantidade Incorreta");

            Produto = produto;
            Preco = produto.Preco;
            Quantidade = quantidade;
            Total = Preco * Quantidade;
        }
    }
}
