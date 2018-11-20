using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services
{
    class PagamentoService : IPagamento
    {
        private readonly IGatewayPagamento _gatewayPagamentoService;

        public PagamentoService(IGatewayPagamento gatewayPagamentoService)
        {
            _gatewayPagamentoService = gatewayPagamentoService;
        }

        public bool EfetuarPagamentoPedido(DetalhePagamento detalhePagamento, decimal valorTotalPedido)
        {
            try
            {
                switch (detalhePagamento.FormaPagamento)
                {
                    case FormaPagamento.CartaoDebito:
                    case FormaPagamento.CartaoCredito:

                        _gatewayPagamentoService.AtribuiInformacoesPagamento("login", "senha", 
                            detalhePagamento.NomeImpressoCartao, valorTotalPedido, detalhePagamento.MesExpiracao, 
                            detalhePagamento.AnoExpiracao, ObtemFormaPagamentoCartao(detalhePagamento.FormaPagamento));

                        _gatewayPagamentoService.EfetuarPagamento();

                        return true;

                    case FormaPagamento.Dinheiro: return true;

                    default: return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FormaPagamentoCartao ObtemFormaPagamentoCartao(FormaPagamento formaPagamento)
        {
            switch (formaPagamento)
            {
                case FormaPagamento.CartaoDebito: return FormaPagamentoCartao.Debito;

                case FormaPagamento.CartaoCredito: return FormaPagamentoCartao.Credito;

                default: throw new ArgumentException("A forma de pagamento informada não é válida."); ;
            }
        }
    }
}
