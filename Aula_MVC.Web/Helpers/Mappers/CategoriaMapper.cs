using Aula_MVC.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aula_MVC.Data.Map;
using Aula_MVC.Domain.Model;
using Aula_MVC.Web.Models;
using AutoMapper;


namespace Aula_MVC.Web.Helpers.Mappers
{
   
    public class CategoriaMapper : ICategoriaMapper
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMapper(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        public Categoria Map(CategoriaViewModel viewModel)
        {
            Mapper.CreateMap<CategoriaViewModel, Categoria>();

            Categoria categoria;

            if (viewModel.Id > 0)
            {
                categoria = _categoriaRepository.GetById(viewModel.Id);
            }
            else
            {
                categoria = new Categoria();
            }
            Mapper.Map(viewModel, categoria);

            return categoria;
        }

        public CategoriaViewModel Map(Categoria domainModel)
        {
            Mapper.CreateMap<Categoria, CategoriaViewModel>()
               .ForMember(a => a.Nome, opt => opt.MapFrom(src => src.Nome))
               ;

            var viewModel = new CategoriaViewModel();

            Mapper.Map(domainModel, viewModel);

            return viewModel;
        }

        public IList<CategoriaViewModel> Map(IList<Categoria> domainModelList)
        {
            return domainModelList.Select(Map).ToList();

        }
    }



    public interface ICategoriaMapper : IMapper<CategoriaViewModel, Categoria>
    {
    }
}