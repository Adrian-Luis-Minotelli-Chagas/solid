using System;
using System.Runtime.InteropServices;
using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;

namespace Daycoval.Solid.Domain.Services
{
    public class PedidoService : IPedido
    {
        private readonly ICarrinho _carrinhoService;
        private readonly IPagamento _pagamentoService;
        private readonly IEstoque _estoqueService;
        private readonly IMail _mailService;
        private readonly ISms _smsService;

        public PedidoService(ICarrinho carrinho, IPagamento pagamento, IEstoque estoqueService, IMail mailService,
            ISms smsService)
        {
            _carrinhoService = carrinho;
            _pagamentoService = pagamento;
            _estoqueService = estoqueService;
            _mailService = mailService;
            _smsService = smsService;
        }

        public void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail,
            bool notificarClienteSms)
        {
            try
            {
                // Parte 1# - Calculo de imposto de produtos e valor total do carrinho.

                // Calcula imposto dos produtos do carrinho
                carrinho.Produtos = _carrinhoService.CalculaImpostoProdutosCarrinho(carrinho.Produtos);

                // Calcula o valor total do carrinho
                carrinho.ValorTotalPedido = _carrinhoService.CalculaValorTotalCarrinho(carrinho.Produtos);

                // Parte 2# - Pagamento do Pedido

                // Realiza o pagamento
                carrinho.FoiPago = _pagamentoService.EfetuarPagamentoPedido(detalhePagamento, carrinho.ValorTotalPedido);

                // Parte 3# - Solicitação e Entrega de Produto(s)
                if (!_carrinhoService.CarrinhoFoiPago(carrinho))
                {
                    throw new ExternalException("O pagamento não foi efetuado.");
                }

                _carrinhoService.SolicitarProdutosCarrinho(carrinho);

                carrinho.FoiEntregue = _carrinhoService.EntregarProdutosCarrinho(carrinho);

                // Parte 4# - Baixa no estoque
                if (!_estoqueService.ProdutosCarrinhoEntregue(carrinho))
                {
                    throw new ExternalException("Os produtos não foram entregues.");
                }

                _carrinhoService.BaixarEstoqueCarrinho(carrinho);

                // Parte 5# - Notificação de Cliente por e-mail
                _mailService.notificarClienteEmail(carrinho.Cliente, notificarClienteEmail);


                // Parte 5# - Notificação de Cliente por SMS
                _smsService.NotificarClienteSms(carrinho.Cliente, notificarClienteSms);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}