using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aula_MVC.Web.Models
{
    public class VendaItemViewModel
    {
        public virtual long Id { get; set; }
        public virtual long ProdutoId { get; set; }
        public virtual string Produto { get; set; }
        public virtual long VendaId { get; set; }
        public virtual string Venda { get; set; }

       
        public virtual decimal Quantidade { get; set; }
        public virtual decimal Total { get; set; }

    }
}