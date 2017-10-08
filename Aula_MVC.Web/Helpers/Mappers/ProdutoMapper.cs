using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aula_MVC.Data.Map;
using Aula_MVC.Domain.Model;
using Aula_MVC.Domain.Repository;
using Aula_MVC.Web.Models;
using AutoMapper;

namespace Aula_MVC.Web.Helpers.Mappers
{
    public class ProdutoMapper : IProdutoMapper
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;


        public ProdutoMapper(IProdutoRepository produtoRepository,ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        public Produto Map(ProdutoViewModel viewModel)
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>()
                .ForMember(a => a.Categoria, opt => opt.MapFrom(src => _categoriaRepository.GetById(src.CategoriaId)))


                ;

            Produto produto;

            if (viewModel.Id > 0)
            {
                produto = _produtoRepository.GetById(viewModel.Id.Value);
            }
            else
            {
                produto = new Produto();
            }
            Mapper.Map(viewModel, produto);

            return produto;
        }

        public ProdutoViewModel Map(Produto domainModel)
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>()
               .ForMember(a => a.Nome, opt => opt.MapFrom(src => src.Nome))
               .ForMember(a => a.Categoria, opt => opt.MapFrom(src => src.Categoria.Nome))
               .ForMember(a => a.CategoriaId, opt => opt.MapFrom(src => src.Categoria.Id))
               .ForMember(a => a.Preco, opt => opt.MapFrom(src => src.Preco))
               .ForMember(a => a.QuantidadeEstoque, opt => opt.MapFrom(src => src.QuantidadeEstoque))
               ;

            var viewModel = new ProdutoViewModel();

            Mapper.Map(domainModel, viewModel);

            return viewModel;
        }

        public IList<ProdutoViewModel> Map(IList<Produto> domainModelList)
        {
            return domainModelList.Select(Map).ToList();

        }
    }
    public interface IProdutoMapper : IMapper<ProdutoViewModel, Produto> { }
}