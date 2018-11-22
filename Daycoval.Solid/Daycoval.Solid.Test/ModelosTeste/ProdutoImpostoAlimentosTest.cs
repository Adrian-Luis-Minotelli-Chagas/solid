using System;
using Daycoval.Solid.Domain.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class ProdutoImpostoAlimentosTest
    {
        [TestMethod]
        public void TestaCalculoImpostoCorreto()
        {
            ProdutoImposto produtoImpostoAlimentos = new ProdutoImpostoAlimentos();

            Assert.AreEqual(0.50M, produtoImpostoAlimentos.CalculaImposto(10));
        }

        [TestMethod]
        public void TestaCalculoImpostoTipoRetornoDiferente()
        {
            ProdutoImposto produtoImpostoAlimentos = new ProdutoImpostoAlimentos();

            double valorEsperado = 0.50;

            Assert.AreNotEqual(valorEsperado, produtoImpostoAlimentos.CalculaImposto(10));
        }

        [TestMethod]
        public void TestaCalculoImpostoValorEsperadoIncorreto()
        {
            ProdutoImposto produtoImpostoAlimentos = new ProdutoImpostoAlimentos();

            Assert.AreNotEqual(0.05M, produtoImpostoAlimentos.CalculaImposto(10));
        }
    }
}
