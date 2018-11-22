using System;
using Daycoval.Solid.Domain.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class ProdutoImpostoEletronicoTest
    {
        [TestMethod]
        public void TestaCalculoImpostoCorreto()
        {
            ProdutoImposto produtoImpostoEletronico = new ProdutoImpostoEletronico();

            Assert.AreEqual(1.5M, produtoImpostoEletronico.CalculaImposto(10));
        }

        [TestMethod]
        public void TestaCalculoImpostoTipoRetornoDiferente()
        {
            ProdutoImposto produtoImpostoEletronico = new ProdutoImpostoEletronico();

            double valorEsperado = 1.5;

            Assert.AreNotEqual(valorEsperado, produtoImpostoEletronico.CalculaImposto(10));
        }

        [TestMethod]
        public void TestaCalculoImpostoValorEsperadoIncorreto()
        {
            ProdutoImposto produtoImpostoEletronico = new ProdutoImpostoEletronico();

            Assert.AreNotEqual(1.499M, produtoImpostoEletronico.CalculaImposto(10));
        }
    }
}
