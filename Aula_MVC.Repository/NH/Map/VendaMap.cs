using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Domain.Model;
using FluentNHibernate.Mapping;

namespace Aula_MVC.Repository.NH.Map
{
    public class VendaMap : ClassMap<Venda>
    {
        public VendaMap()
        {
            Table("vnd_venda");
            Id(x => x.Id).Column("idVenda").GeneratedBy.Identity();
            Map(x => x.NomeCliente).Column("nomeCliente");
            Map(x => x.DataVenda).Column("dataVenda");
            Map(x => x.Total).Column("total");
            HasMany(x => x.Itens).KeyColumn("idVenda").Cascade.AllDeleteOrphan();

        }
    }
}
