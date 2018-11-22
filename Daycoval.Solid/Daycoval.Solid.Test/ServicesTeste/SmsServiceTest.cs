using System;
using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using Daycoval.Solid.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class SmsServiceTest
    {
        [TestMethod]
        public void TestaNotificarClienteSmsComCelularInvalidoSemException()
        {
            ISms smsService = new SmsService();

            Cliente cliente = new Cliente
            {
                Celular = null
            };

            smsService.NotificarClienteSms(cliente, true);
        }

        [TestMethod]
        public void TestaNotificarClienteSmsComCelularValidoEIndicadorDeEnvioFalsoSemException()
        {
            ISms smsService = new SmsService();

            Cliente cliente = new Cliente
            {
                Celular = "900000000"
            };

            smsService.NotificarClienteSms(cliente, false);
        }
    }
}
