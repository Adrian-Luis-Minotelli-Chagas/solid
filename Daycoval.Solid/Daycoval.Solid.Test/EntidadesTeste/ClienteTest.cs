using System;
using Daycoval.Solid.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void testaValidacaoEmailEmBranco()
        {
            Cliente cliente = new Cliente
            {
                Email = " "
            };

            Assert.IsFalse(cliente.EmailValido());

        }

        [TestMethod]
        public void testaValidacaoEmailNulo()
        {
            Cliente cliente = new Cliente
            {
                Email = null
            };

            Assert.IsFalse(cliente.EmailValido());

        }

        [TestMethod]
        public void testaValidacaoEmailPreenchidoCorretamente()
        {
            Cliente cliente = new Cliente
            {
                Email = "adrian@gmail.com"
            };

            Assert.IsTrue(cliente.EmailValido());
        }

        [TestMethod]
        public void testaValidacaoCelularEmBranco()
        {
            Cliente cliente = new Cliente
            {
                Celular = " "
            };

            Assert.IsFalse(cliente.CelularValido());

        }

        [TestMethod]
        public void testaValidacaoCelularNulo()
        {
            Cliente cliente = new Cliente
            {
                Celular = null
            };

            Assert.IsFalse(cliente.CelularValido());

        }

        [TestMethod]
        public void testaValidacaoCelularPreenchidoCorretamente()
        {
            Cliente cliente = new Cliente
            {
                Celular = "900000000"
            };

            Assert.IsTrue(cliente.CelularValido());
        }
    }
}
