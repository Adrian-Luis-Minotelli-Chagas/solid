using Daycoval.Solid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Interfaces
{
    public interface IEstoque
    {
        void SolicitarProduto(Produto produto);
        void BaixarEstoque(Produto produto);
        bool ProdutosCarrinhoEntregue(Carrinho carrinho);
    }
}
