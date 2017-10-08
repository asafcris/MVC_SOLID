using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula_MVC.Web.Controllers
{
   
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
      
      
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Meu Contato.";

            return View();
        }
    }
}