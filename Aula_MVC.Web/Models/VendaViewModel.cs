using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Aula_MVC.Domain.Model;

namespace Aula_MVC.Web.Models
{
    public class VendaViewModel
    {
        public virtual long Id { get; set; }
        [DisplayName("Nome Cliente")]
        public virtual string NomeCliente { get; set; }
        public virtual DateTime DataVenda { get; set; }
        public virtual decimal Total { get; set; }
        public virtual IList<VendaItem> Itens { get; set; }
        public string ProdutoQauntidade { get; set; }

    }
}