using System;
using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using Daycoval.Solid.Domain.Modelos;
using Daycoval.Solid.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class ProdutoImpostoServiceTest
    {
        [TestMethod]
        public void TestaObtemProdutoImpostoPorTipoAlimentos()
        {
            IProdutoImposto produtoImpostoService = new ProdutoImpostoService();

            ProdutoImposto pordutoImpostoObj = produtoImpostoService.ObtemProdutoImpostoPorTipo(TipoProduto.Alimentos);

            Assert.IsInstanceOfType(new ProdutoImpostoAlimentos(), pordutoImpostoObj.GetType());
        }

        [TestMethod]
        public void TestaObtemProdutoImpostoPorTipoEletronico()
        {
            IProdutoImposto produtoImpostoService = new ProdutoImpostoService();

            ProdutoImposto pordutoImpostoObj = produtoImpostoService.ObtemProdutoImpostoPorTipo(TipoProduto.Eletronico);

            Assert.IsInstanceOfType(new ProdutoImpostoEletronico(), pordutoImpostoObj.GetType());
        }

        [TestMethod]
        public void TestaObtemProdutoImpostoPorTipoSuperfulos()
        {
            IProdutoImposto produtoImpostoService = new ProdutoImpostoService();

            ProdutoImposto pordutoImpostoObj = produtoImpostoService.ObtemProdutoImpostoPorTipo(TipoProduto.Superfulos);

            Assert.IsInstanceOfType(new ProdutoImpostoSuperfulos(), pordutoImpostoObj.GetType());
        }
    }
}
