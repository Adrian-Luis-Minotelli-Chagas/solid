using System;
using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;

namespace Daycoval.Solid.Domain.Services
{
    public class GatewayPagamentoService : IDisposable, IGatewayPagamento
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string NomeImpresso { get; set; }
        public decimal Valor { get; set; }
        public int MesExpiracao { get; set; }
        public int AnoExpiracao { get; set; }
        public FormaPagamentoCartao FormaPagamentoCartao { get; set; }

        public void AtribuiInformacoesPagamento(string _Login, string _Senha, string _NomeImpresso,
            decimal _Valor, int _MesExpiracao, int _AnoExpiracao, FormaPagamentoCartao _FormaPagamentoCartao)
        {
            Login = _Login;
            Senha = _Senha;
            FormaPagamentoCartao = _FormaPagamentoCartao;
            NomeImpresso = _NomeImpresso;
            AnoExpiracao = _AnoExpiracao;
            MesExpiracao = _MesExpiracao;
            Valor = _Valor;
        }

        public void EfetuarPagamento()
        {
            //Não é necessário implementar este método.
        }

        public void Dispose()
        {
            Login = string.Empty;
            Senha = string.Empty;
            NomeImpresso = string.Empty;
            Valor = 0M;
            MesExpiracao = 0;
            AnoExpiracao = 0;
        }
    }
}