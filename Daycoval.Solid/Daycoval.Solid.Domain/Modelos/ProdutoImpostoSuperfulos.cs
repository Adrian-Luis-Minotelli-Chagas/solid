using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Modelos
{
    public class ProdutoImpostoSuperfulos : ProdutoImposto
    {
        private readonly decimal taxa = 0.20M;

        public override decimal CalculaImposto(decimal valor)
        {
            return valor * this.taxa;
        }
    }
}
