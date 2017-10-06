using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Data.NHibernate;
using Aula_MVC.Domain.Model;
using Aula_MVC.Domain.Repository;

namespace Aula_MVC.Repository.NH.Impl
{
   public class VendaRepository : Repository<Venda>, IVendaRepository
   {
    }
}
