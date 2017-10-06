using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Data.Domain;
using Aula_MVC.Data.Helpers;

namespace Aula_MVC.Domain.Model
{
    public class Categoria : IEntity
    {
        public virtual long Id { get; set; }
        public virtual string Nome { get; set; }

        public Categoria(string name)
        {
            ValidateNameAndSetName(name);
        }
        private void ValidateNameAndSetName(string nome)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome obrigatório");
            DomainException.When(nome.Length < 3, "Nome  inválido");

            Nome = nome;
        }
    }
}
