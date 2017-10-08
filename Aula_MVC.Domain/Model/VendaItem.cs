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
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }

        public virtual decimal Preco { get; set; }
        public virtual decimal Quantidade { get; set; }
        public virtual decimal Total { get; set; }

       
    }
}
