
using System;
using Aula_MVC.Domain.Model;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;


namespace Aula_MVC.UnitTest.UnitTest
{
    [TestFixture]
    public class VendaTest
    {

        [Test]
        public void Verifica_Estoque_E_Qtd_Zerada_Passando_Quantidade_Zerada()
        {
            var msg = String.Empty;
            var vendaItem = new VendaItem();
            var produto = new Produto();
            vendaItem.Quantidade = 0;
            produto.QuantidadeEstoque = 2;
            vendaItem.Produto = produto;
            var obj = vendaItem.Verifica_Estoque_E_Qtd_Zerada(out msg);
            Assert.AreEqual(false,obj);
        }

        [Test]
        public void Verifica_Estoque_E_Qtd_Zerada_Passando_Quantidade_Maioir_Estoque()
        {
            var msg = String.Empty;
            var vendaItem = new VendaItem();
            var produto = new Produto();
            vendaItem.Quantidade = 3;
            produto.QuantidadeEstoque = 2;
            vendaItem.Produto = produto;
            var obj = vendaItem.Verifica_Estoque_E_Qtd_Zerada(out msg);
            Assert.AreEqual(false, obj);
        }
        [Test]
        public void Verifica_Estoque_E_Qtd_Zerada_Passando_Quantidade_Menor_Estoque()
        {
            var msg = String.Empty;
            var vendaItem = new VendaItem();
            var produto = new Produto();
            vendaItem.Quantidade = 3;
            produto.QuantidadeEstoque = 3;
            vendaItem.Produto = produto;
            var obj = vendaItem.Verifica_Estoque_E_Qtd_Zerada(out msg);
            Assert.AreEqual(true, obj);
        }
        [Test]
        public void Verifica_Baixa_Estoque()
        {
            var vendaItem = new VendaItem();
            var produto = new Produto();
            vendaItem.Quantidade = 3;
            produto.QuantidadeEstoque = 3;
            vendaItem.Produto = produto;
            var obj = vendaItem.Produto.Diminuir_Quantidade_Venda(3);
            Assert.AreEqual(0, obj);
        }
    }
}
