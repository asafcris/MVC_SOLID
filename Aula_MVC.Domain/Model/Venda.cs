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
       public virtual long Id { get; set; }
        public string NomeCliente { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal Total { get; private set; }
        public virtual IList<VendaItem> Itens { get; set; }


    }
}
