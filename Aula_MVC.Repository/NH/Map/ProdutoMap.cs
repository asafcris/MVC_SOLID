using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Domain.Model;
using FluentNHibernate.Mapping;

namespace Aula_MVC.Repository.NH.Map
{
    public class ProdutoMap : ClassMap<Produto>
    {
        public ProdutoMap()
        {
            Table("vnd_produto");
            Id(x => x.Id).Column("idProduto").GeneratedBy.Identity();
            References(x => x.Categoria).Column("idCategoria");
            Map(x => x.Nome).Column("nome");
            Map(x => x.Preco).Column("preco");
            Map(x => x.QuantidadeEstoque).Column("quantidadeEstoque");
        }
    }
}
