using System;
using System.Collections.Generic;
using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using Daycoval.Solid.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Daycoval.Solid.Test
{
    [TestClass]
    public class CarrinhoServiceTest
    {
        [TestMethod]
        public void TestaCalculaImpostoProdutosCarrinho()
        {
            decimal valorTotalImposto = 40M;
            decimal valorTotalImpostoAux = 0M;

            IProdutoImposto produtoImpostoService = new ProdutoImpostoService();
            IEstoque estoqueService = new EstoqueService();

            ICarrinho carrinhoService = new CarrinhoService(produtoImpostoService, estoqueService);

            Carrinho carrinho = new Carrinho
            {
                Produtos = new List<Produto>()
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

            List<Produto> listaProdutos = carrinhoService.CalculaImpostoProdutosCarrinho(carrinho.Produtos);

            foreach (Produto produto in listaProdutos)
            {
                valorTotalImpostoAux += produto.ValorImposto;
            }

            Assert.AreEqual(valorTotalImposto, valorTotalImpostoAux);
        }

        [TestMethod]
        public void TestaCalculaValorTotalCarrinho()
        {
            decimal valorTotalPedidoEsperado = 1020.00M;

            IProdutoImposto produtoImpostoService = new ProdutoImpostoService();
            IEstoque estoqueService = new EstoqueService();

            ICarrinho carrinhoService = new CarrinhoService(produtoImpostoService, estoqueService);

            Carrinho carrinho = new Carrinho
            {
                Produtos = new List<Produto>()
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

            carrinho.Produtos = carrinhoService.CalculaImpostoProdutosCarrinho(carrinho.Produtos);

            carrinho.ValorTotalPedido = carrinhoService.CalculaValorTotalCarrinho(carrinho.Produtos);

            Assert.AreEqual(valorTotalPedidoEsperado, carrinho.ValorTotalPedido);
        }


        [TestMethod]
        public void TestaChamadaSolicitarProdutosCarrinho()
        {
            IProdutoImposto produtoImpostoService = new ProdutoImpostoService();
            IEstoque estoqueService = new EstoqueService();

            ICarrinho carrinhoService = new CarrinhoService(produtoImpostoService, estoqueService);

            Carrinho carrinho = new Carrinho
            {
                Produtos = new List<Produto>()
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

            carrinhoService.SolicitarProdutosCarrinho(carrinho);
        }

        [TestMethod]
        public void TestaChamadaBaixarEstoqueCarrinho()
        {
            IProdutoImposto produtoImpostoService = new ProdutoImpostoService();
            IEstoque estoqueService = new EstoqueService();

            ICarrinho carrinhoService = new CarrinhoService(produtoImpostoService, estoqueService);

            Carrinho carrinho = new Carrinho
            {
                Produtos = new List<Produto>()
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

            carrinhoService.BaixarEstoqueCarrinho(carrinho);
        }
        
    }

}
