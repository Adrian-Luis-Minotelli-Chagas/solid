using Daycoval.Solid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Interfaces
{
    public interface ICarrinho
    {
        List<Produto> CalculaImpostoProdutosCarrinho(List<Produto> listaProdutos);

        decimal CalculaValorTotalCarrinho(List<Produto> listaProdutos);

        void SolicitarProdutosCarrinho(Carrinho carrinho);

        bool CarrinhoFoiPago(Carrinho carrinho);

        void BaixarEstoqueCarrinho(Carrinho carrinho);

        bool EntregarProdutosCarrinho(Carrinho carrinho);
    }
}
