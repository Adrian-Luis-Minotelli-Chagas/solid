using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using Daycoval.Solid.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Daycoval.Solid.Domain.Services
{
    class CarrinhoService : ICarrinho
    {
        private readonly IProdutoImposto _produtoImpostoService;
        private readonly IEstoque _estoqueService;

        public CarrinhoService(IProdutoImposto produtoImposto, IEstoque estoque)
        {
            _produtoImpostoService = produtoImposto;
            _estoqueService = estoque;
        }

        public List<Produto> CalculaImpostoProdutosCarrinho(List<Produto> listaProdutos)
        {
            try
            {

                foreach (Produto produto in listaProdutos)
                {
                    ProdutoImposto produtoImposto = _produtoImpostoService.ObtemProdutoImpostoPorTipo(produto.TipoProduto);

                    produto.ValorImposto = produtoImposto.CalculaImposto(produto.Valor);
                }

                return listaProdutos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal CalculaValorTotalCarrinho(List<Produto> listaProdutos)
        {
            try
            {
                decimal valorTotalAux = 0;

                foreach (Produto produto in listaProdutos)
                {
                    valorTotalAux += (produto.Valor + produto.ValorImposto) * produto.Quantidade;
                }

                return valorTotalAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EntregarProdutosCarrinho(Carrinho carrinho)
        {
            return true;
        }

        public void SolicitarProdutosCarrinho(Carrinho carrinho)
        {
            foreach (Produto produto in carrinho.Produtos)
            {
                _estoqueService.SolicitarProduto(produto);
            }
        }

        public void BaixarEstoqueCarrinho(Carrinho carrinho)
        {
            foreach (Produto produto in carrinho.Produtos)
            {
                _estoqueService.BaixarEstoque(produto);
            }
        }

        public bool CarrinhoFoiPago(Carrinho carrinho)
        {
            return carrinho.FoiPago;
        }

    }
}
