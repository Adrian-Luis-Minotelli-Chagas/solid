using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Interfaces
{
    public interface IProdutoImposto
    {
        ProdutoImposto ObtemProdutoImpostoPorTipo(TipoProduto tipoProduto);
    }
}
