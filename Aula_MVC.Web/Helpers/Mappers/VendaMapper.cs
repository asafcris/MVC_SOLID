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
    public class VendaMapper : IVendaMapper
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaMapper(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;

        }

        public Venda Map(VendaViewModel viewModel)
        {
            Mapper.CreateMap<VendaViewModel, Venda>();

            Venda venda;

            if (viewModel.Id > 0)
            {
                venda = _vendaRepository.GetById(viewModel.Id);
            }
            else
            {
                venda = new Venda();
            }

            Mapper.Map(viewModel, venda);

            return venda;

        }

        public VendaViewModel Map(Venda domainModel)
        {
            Mapper.CreateMap<Venda, VendaViewModel>()
               .ForMember(a => a.DataVenda, opt => opt.MapFrom(src => src.DataVenda))
               .ForMember(a => a.NomeCliente, opt => opt.MapFrom(src => src.NomeCliente))
               .ForMember(a => a.Total, opt => opt.MapFrom(src => src.Total))
               .ForMember(a => a.Itens, opt => opt.Ignore())
               ;

            var viewModel = new VendaViewModel();
            viewModel.Produto = string.Join(",", domainModel.Itens.Select(x => x.Produto.Nome));

            Mapper.Map(domainModel, viewModel);

            return viewModel;
        }

        public IList<VendaViewModel> Map(IList<Venda> domainModelList)
        {
            return domainModelList.Select(Map).ToList();
        }
    }
    public interface IVendaMapper : IMapper<VendaViewModel, Venda> { }
}