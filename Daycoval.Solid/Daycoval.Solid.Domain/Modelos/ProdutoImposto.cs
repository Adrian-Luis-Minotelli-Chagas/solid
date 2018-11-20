using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Modelos
{
    public abstract class ProdutoImposto
    {
        public abstract decimal CalculaImposto(decimal valor);
    }
}
