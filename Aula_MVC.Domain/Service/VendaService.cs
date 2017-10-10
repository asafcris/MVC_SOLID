using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aula_MVC.Domain.Model;
using Aula_MVC.Domain.Repository;

namespace Aula_MVC.Domain.Service
{
    public class VendaService : IVendaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IVendaRepository _vendaRepository;
        

        public VendaService(ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository, IVendaRepository vendaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
            _vendaRepository = vendaRepository;
        }


        public Venda Salvar(long id,
            long[] produtoId,
            decimal[] quantidade,
            DateTime dataVenda,
            string cliente
           )
        {
            Venda venda = null;

             if (id > 0)
            {
                venda = _vendaRepository.GetById(id);
            }
            else
            {
                venda = new Venda
                {
                    NomeCliente = cliente,
                    DataVenda = DateTime.Now
                };
            }
          
            //Atualiza de acordo com o que foi digitado
            venda.Itens.Clear();
            for (int i = 0; i < produtoId.Count(); i++)
            {
                var prod = _produtoRepository.GetById(produtoId[i]);
               
                var item = new VendaItem()
                {
                    Venda = venda,
                    Produto = prod,
                    Quantidade = quantidade[i],
                    Total = quantidade[i] * prod.Preco
                };
                var msg = string.Empty;
                //if (prod.QuantidadeEstoque < quantidade[i])
                if (!item.Verifica_Estoque_E_Qtd_Zerada(out msg))
                {
                    throw new InvalidOperationException(msg);
                }
               
                prod.Diminuir_Quantidade_Venda(quantidade[i]);

                venda.Itens.Add(item);
            }
            venda.Total = venda.Itens.Sum(x => x.Total);
            _vendaRepository.Save(venda);
            _vendaRepository.CommitTran();

            return venda; }
    }
    public interface IVendaService
    {
        Venda Salvar(
           
            long id,
            long[] produtoId,
            decimal[] quantidade,
            DateTime dataVenda,
            string cliente
           );
    }
}
