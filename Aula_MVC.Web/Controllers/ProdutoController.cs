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
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoMapper _produtoMapper;

        public ProdutoController(IProdutoRepository produtoRepository, IProdutoMapper produtoMapper,ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _produtoMapper = produtoMapper;
            _categoriaRepository = categoriaRepository;
        }

        private void carregarViewBag()
        {
            ViewBag.Categoria = _categoriaRepository.GetAll().ToList();

        }
        public ActionResult Cadastro()
        {
            carregarViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(ProdutoViewModel viewModel)
        {
            carregarViewBag();

            if (ModelState.IsValid)
            {
                try
                {


                    var obj = _produtoRepository.Save(_produtoMapper.Map(viewModel));
                    _produtoRepository.CommitTran();


                    TempData["success"] = "Operação Realizado com sucesso!";
                }
                catch (Exception ex)
                {
                    TempData["warning"] = "ops! Erro na operação ! " + ex.Message;
                }
            }
            else
            {
                TempData["warning"] = "Erro na validação do Formulário";
                return View();
            }


            return RedirectToAction("Lista");
        }

        public ActionResult Editar(long id)
        {
            carregarViewBag();

            var obj = _produtoRepository.GetById(id);

            return View("Cadastro", _produtoMapper.Map(obj));
        }

        public ActionResult Lista()
        {
            var obj = _produtoRepository.GetAll().ToList();

            return View("Lista", _produtoMapper.Map(obj));
        }
    }
}