using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Modelos
{
    public class ProdutoImpostoEletronico : ProdutoImposto
    {
        private readonly decimal taxa = 0.15M;

        public override decimal CalculaImposto(decimal valor)
        {
            return valor * this.taxa;
        }
    }
}
