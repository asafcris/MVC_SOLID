using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula_MVC.Domain.Repository;
using Aula_MVC.Web.Helpers.Mappers;
using Aula_MVC.Web.Models;

namespace Aula_MVC.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaMapper _categoriaMapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, ICategoriaMapper categoriaMapper)
        {
            _categoriaRepository = categoriaRepository;
            _categoriaMapper = categoriaMapper;

        }



        public ActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   

                    var obj = _categoriaRepository.Save(_categoriaMapper.Map(viewModel));
                    _categoriaRepository.CommitTran();


                    TempData["success"] = "Operação Realizado com sucesso!";
                }
                catch (Exception ex)
                {
                    TempData["warning"] = "ops! Erro na operação ! " + ex.Message;
                }
            }
            else
            {
                TempData["warning"] = "Erro na validação do Formulário" ;
                return View();
            }
            

            return RedirectToAction("Lista");
        }

        public ActionResult Editar(long id)
        {
            var obj = _categoriaRepository.GetById(id);

            return View("Cadastro",_categoriaMapper.Map(obj));
        }

        public ActionResult Lista()
        {
            var obj = _categoriaRepository.GetAll().ToList();
           
            return View("Lista", _categoriaMapper.Map(obj));
        }
    }
}