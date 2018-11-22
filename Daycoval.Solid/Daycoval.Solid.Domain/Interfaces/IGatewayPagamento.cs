using Daycoval.Solid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Interfaces
{
    public interface IGatewayPagamento
    {
        void AtribuiInformacoesPagamento(string _Login, string _Senha, string _NomeImpresso,
            decimal _Valor, int _MesExpiracao, int _AnoExpiracao, FormaPagamentoCartao _FormaPagamentoCartao);

        void EfetuarPagamento();
    }
}
