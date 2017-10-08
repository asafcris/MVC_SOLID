using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aula_MVC.Domain.Model;
using Aula_MVC.Domain.Repository;
using Aula_MVC.Domain.Service;
using Aula_MVC.Web.Helpers.Mappers;
using Aula_MVC.Web.Models;

namespace Aula_MVC.Web.Controllers
{
    public class VendaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;
        private readonly IVendaService _vendaService;
        private readonly IVendaMapper _vendaMapper;

        public VendaController(ICategoriaRepository categoriaRepository,IProdutoRepository produtoRepository,IVendaRepository vendaRepository, IVendaService vendaService, IVendaMapper vendaMapper)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
            _vendaService = vendaService;
            _vendaMapper = vendaMapper;
        }

        private void carregarViewBag()
        {
            ViewBag.Produtos = _produtoRepository.GetAll().ToList();

        }


        public ActionResult Cadastro()
        {
            carregarViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastro(VendaViewModel viewModel, long[] produtoId, decimal[] quantidade)
        {
            carregarViewBag();
            try
            {
                var obj = _vendaService.Salvar(viewModel.Id, produtoId, quantidade, DateTime.Now, viewModel.NomeCliente);
                TempData["success"] = "Operação Realizado com sucesso!";
            }
            catch (Exception ex)
            {

                TempData["warning"] = "ops! Erro na operação ! " + ex.Message;
                return View();
            }


            return RedirectToAction("Lista");
        }

        public ActionResult NovoItemVenda()
        {
            carregarViewBag();
            return PartialView("_VendaItem", new VendaItemViewModel());
        }
        public ActionResult Lista()
        {
            var obj = _vendaRepository.GetAll().ToList();

            return View("Lista", _vendaMapper.Map(obj));
        }
    }
}