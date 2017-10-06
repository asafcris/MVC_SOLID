using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Domain.Model;
using FluentNHibernate.Mapping;


namespace Aula_MVC.Repository.NH.Map
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        public CategoriaMap()
        {
            Table("vnd_categoria");
            Id(x => x.Id).Column("idCategoria").GeneratedBy.Identity();
            Map(x => x.Nome).Column("nome");
        }
    }
}
