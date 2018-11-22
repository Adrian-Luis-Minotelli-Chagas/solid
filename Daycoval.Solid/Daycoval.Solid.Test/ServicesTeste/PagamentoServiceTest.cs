using System;
using Daycoval.Solid.Domain.Services;
using Daycoval.Solid.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Daycoval.Solid.Domain.Enums;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class PagamentoServiceTest
    {
        [TestMethod]
        public void TestaObtemFormaPagamentoCartaoDebito()
        {
            IGatewayPagamento gatewayPagamentoService = new GatewayPagamentoService();

            PagamentoService pagamentoService = new PagamentoService(gatewayPagamentoService);

            Assert.AreEqual(FormaPagamentoCartao.Debito, pagamentoService.ObtemFormaPagamentoCartao(FormaPagamento.CartaoDebito));
        }

        [TestMethod]
        public void TestaObtemFormaPagamentoCartaoCredito()
        {
            IGatewayPagamento gatewayPagamentoService = new GatewayPagamentoService();

            PagamentoService pagamentoService = new PagamentoService(gatewayPagamentoService);

            Assert.AreEqual(FormaPagamentoCartao.Credito, pagamentoService.ObtemFormaPagamentoCartao(FormaPagamento.CartaoCredito));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "A forma de pagamento informada não é válida.")]
        public void TestaObtemFormaPagamentoInvalido()
        {
            IGatewayPagamento gatewayPagamentoService = new GatewayPagamentoService();

            PagamentoService pagamentoService = new PagamentoService(gatewayPagamentoService);

            pagamentoService.ObtemFormaPagamentoCartao(FormaPagamento.Dinheiro);
        }

        [TestMethod]
        public void TestaEfetuarPagamentoPedidoCartaoDebito()
        {
            decimal valorTotalPedido = 1000.00M;

            IGatewayPagamento gatewayPagamentoService = new GatewayPagamentoService();

            PagamentoService pagamentoService = new PagamentoService(gatewayPagamentoService);

            DetalhePagamento detalhePagamento = new DetalhePagamento
            {
                FormaPagamento = FormaPagamento.CartaoDebito,
                NumeroCartao = "12453",
                MesExpiracao = 4,
                AnoExpiracao = 2022,
                NomeImpressoCartao = "ADRIAN"
            };

            Assert.IsTrue(pagamentoService.EfetuarPagamentoPedido(detalhePagamento, valorTotalPedido));
        }

        [TestMethod]
        public void TestaEfetuarPagamentoPedidoCartaoCredito()
        {
            decimal valorTotalPedido = 1000.00M;

            IGatewayPagamento gatewayPagamentoService = new GatewayPagamentoService();

            PagamentoService pagamentoService = new PagamentoService(gatewayPagamentoService);

            DetalhePagamento detalhePagamento = new DetalhePagamento
            {
                FormaPagamento = FormaPagamento.CartaoCredito,
                NumeroCartao = "12453",
                MesExpiracao = 4,
                AnoExpiracao = 2022,
                NomeImpressoCartao = "ADRIAN"
            };

            Assert.IsTrue(pagamentoService.EfetuarPagamentoPedido(detalhePagamento, valorTotalPedido));
        }

        [TestMethod]
        public void TestaEfetuarPagamentoPedidoCartaoDinheiro()
        {
            decimal valorTotalPedido = 1000.00M;

            IGatewayPagamento gatewayPagamentoService = new GatewayPagamentoService();

            PagamentoService pagamentoService = new PagamentoService(gatewayPagamentoService);

            DetalhePagamento detalhePagamento = new DetalhePagamento
            {
                FormaPagamento = FormaPagamento.Dinheiro,
                NumeroCartao = "12453",
                MesExpiracao = 4,
                AnoExpiracao = 2022,
                NomeImpressoCartao = "ADRIAN"
            };

            Assert.IsTrue(pagamentoService.EfetuarPagamentoPedido(detalhePagamento, valorTotalPedido));
        }

    }
}
