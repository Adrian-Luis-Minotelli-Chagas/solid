using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Modelos
{
    class ProdutoImpostoAlimentos : ProdutoImposto
    {
        private readonly decimal taxa = 0.05M;

        public override decimal CalculaImposto(decimal valor)
        {
            return valor * this.taxa;
        }
    }
}
