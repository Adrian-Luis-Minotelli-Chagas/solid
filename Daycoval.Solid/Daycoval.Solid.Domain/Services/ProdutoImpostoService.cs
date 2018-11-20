using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using Daycoval.Solid.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services
{
    class ProdutoImpostoService : IProdutoImposto
    {
        public ProdutoImposto ObtemProdutoImpostoPorTipo(TipoProduto tipoProduto) 
        {
            switch (tipoProduto)
            {
                case TipoProduto.Alimentos:
                    return new ProdutoImpostoAlimentos();

                case TipoProduto.Eletronico:
                    return new ProdutoImpostoEletronico();

                case TipoProduto.Superfulos:
                    return new ProdutoImpostoSuperfulos();

                default: throw new ArgumentException("O tipo de produto informado não está disponível.");
            }
        }
    }
}