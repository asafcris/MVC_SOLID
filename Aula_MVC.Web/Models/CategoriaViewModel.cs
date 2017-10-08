using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Aula_MVC.Data.Helpers;


namespace Aula_MVC.Web.Models
{
    public class CategoriaViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Favor digite o nome corretamente")]
        [MinLength(3, ErrorMessage = "O tamanho mínimo do nome são 3 caracteres.")]
        public string Nome { get; set; }

    }
}