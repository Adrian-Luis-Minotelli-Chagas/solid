using System;
using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using Daycoval.Solid.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class MailServiceTest
    {

        [TestMethod]
        public void TestaNotificarClienteEmailComEmailInvalidoSemException()
        {
            IMail mailService = new MailService();

            Cliente cliente = new Cliente
            {
                Email = "    "
            };

            mailService.notificarClienteEmail(cliente, true);
        }

        [TestMethod]
        public void TestaNotificarClienteEmailComEmailValidoEIndicadorDeEnvioFalsoSemException()
        {
            IMail mailService = new MailService();

            Cliente cliente = new Cliente
            {
                Email = "adrian@gmail.com"
            };

            mailService.notificarClienteEmail(cliente, false);
        }
    }
}
