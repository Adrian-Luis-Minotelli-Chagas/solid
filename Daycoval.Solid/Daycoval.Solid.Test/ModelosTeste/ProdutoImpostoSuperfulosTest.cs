using System;
using Daycoval.Solid.Domain.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class ProdutoImpostoSuperfulosTest
    {
        [TestMethod]
        public void TestaCalculoImpostoCorreto()
        {
            ProdutoImposto produtoImpostoSuperfulosTest = new ProdutoImpostoSuperfulos();

            Assert.AreEqual(2.0M, produtoImpostoSuperfulosTest.CalculaImposto(10));
        }

        [TestMethod]
        public void TestaCalculoImpostoTipoRetornoDiferente()
        {
            ProdutoImposto produtoImpostoSuperfulosTest = new ProdutoImpostoSuperfulos();

            double valorEsperado = 2.0;

            Assert.AreNotEqual(valorEsperado, produtoImpostoSuperfulosTest.CalculaImposto(10));
        }

        [TestMethod]
        public void TestaCalculoImpostoValorEsperadoIncorreto()
        {
            ProdutoImposto produtoImpostoSuperfulosTest = new ProdutoImpostoSuperfulos();

            Assert.AreNotEqual(2.001M, produtoImpostoSuperfulosTest.CalculaImposto(10));
        }
    }
}
