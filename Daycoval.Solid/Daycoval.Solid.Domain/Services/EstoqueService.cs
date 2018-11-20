using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using System.Collections.Generic;

namespace Daycoval.Solid.Domain.Services
{
    public class EstoqueService : IEstoque
    {
        public void SolicitarProduto(Produto produto)
        {
            //Este método não precisa ser implementado.
        }

        public void BaixarEstoque(Produto produto)
        {
            //Este método não precisa ser implementado.
        }

        public bool ProdutosCarrinhoEntregue(Carrinho carrinho)
        {
            return carrinho.FoiEntregue;
        }
    }
}