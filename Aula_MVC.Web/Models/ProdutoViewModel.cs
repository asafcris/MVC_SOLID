using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula_MVC.Web.Models
{
    public class ProdutoViewModel
    {
       
        public  long? Id { get; set; }
        public  string Nome { get; set; }
        [Required]
        public  long CategoriaId { get; set; }
        
        public  string Categoria { get;  set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public  decimal Preco { get; set; }
        public  int QuantidadeEstoque { get; set; }



    }
}