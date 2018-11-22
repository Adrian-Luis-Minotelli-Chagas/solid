using System;
using System.Collections.Generic;
using System.Net.Mail;
using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using Daycoval.Solid.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class PedidoServiceTest
    {
        [TestMethod]
        public void TestaEfetuarPedido()
        {
            try
            {
                bool notificarClienteEmail = false;
                bool notificarClienteSms = true;

                IProdutoImposto produtoImpostoService = new ProdutoImpostoService();
                IEstoque estoqueService = new EstoqueService();

                ICarrinho carrinhoService = new CarrinhoService(produtoImpostoService, estoqueService);

                IGatewayPagamento gatewayPagamentoService = new GatewayPagamentoService();

                IPagamento pagamentoService = new PagamentoService(gatewayPagamentoService);

                IMail mailService = new MailService();

                ISms smsService = new SmsService();

                IPedido pedidoService = new PedidoService(carrinhoService, pagamentoService, estoqueService,
                    mailService, smsService);

                Cliente cliente = new Cliente
                {
                    Cpf = "443",
                    Nome = "ADRIAN",
                    Email = "adrian@gmail.com",
                    Celular = "900000000"
                };

                Carrinho carrinho = new Carrinho
                {
                    Produtos = new List<Produto>(),
                    Cliente = cliente,
                    FoiEntregue = false,
                    FoiPago = false,
                    ValorTotalPedido = 0M
                };

                carrinho.Produtos.Add(new Produto
                {
                    Descricao = "",
                    Valor = 100M,
                    Quantidade = 3,
                    ValorImposto = 0M,
                    TipoProduto = TipoProduto.Alimentos
                });

                carrinho.Produtos.Add(new Produto
                {
                    Descricao = "",
                    Valor = 100M,
                    Quantidade = 3,
                    ValorImposto = 0M,
                    TipoProduto = TipoProduto.Eletronico
                });

                carrinho.Produtos.Add(new Produto
                {
                    Descricao = "",
                    Valor = 100M,
                    Quantidade = 3,
                    ValorImposto = 0M,
                    TipoProduto = TipoProduto.Superfulos
                });

                DetalhePagamento detalhePagamento = new DetalhePagamento
                {
                    FormaPagamento = FormaPagamento.CartaoDebito,
                    NumeroCartao = "12453",
                    MesExpiracao = 4,
                    AnoExpiracao = 2022,
                    NomeImpressoCartao = "ADRIAN"
                };

                pedidoService.EfetuarPedido(carrinho, detalhePagamento, notificarClienteEmail, notificarClienteSms);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exceção não esperada: " + ex.Message);
            }
        }

    }
}
