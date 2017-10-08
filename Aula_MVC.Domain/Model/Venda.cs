using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Data.Domain;

namespace Aula_MVC.Domain.Model
{
   public class Venda : IEntity
    {
       public Venda()
       {
           Itens = new List<VendaItem>();
       }
       public virtual long Id { get; set; }
        public virtual string NomeCliente { get;  set; }
        public virtual DateTime DataVenda { get;  set; }
        public virtual decimal Total { get;  set; }
        public virtual IList<VendaItem> Itens { get; set; }


    }
}
