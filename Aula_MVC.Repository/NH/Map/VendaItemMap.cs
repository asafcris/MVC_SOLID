using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Domain.Model;
using FluentNHibernate.Mapping;

namespace Aula_MVC.Repository.NH.Map
{
   public class VendaItemMap : ClassMap<VendaItem>
   {
       public VendaItemMap()
       {
            Table("vnd_vendaItem");
            Id(x => x.Id).Column("idVendaItem").GeneratedBy.Identity();
            References(x => x.Produto).Column("idProduto");
            References(x => x.Venda).Column("idVenda");
            Map(x => x.Preco).Column("preco");
            Map(x => x.Quantidade).Column("quantidade");
            Map(x => x.Total).Column("total");
        }
    }
}
