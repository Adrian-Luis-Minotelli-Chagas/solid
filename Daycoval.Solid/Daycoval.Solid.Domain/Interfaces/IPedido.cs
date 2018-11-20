using Daycoval.Solid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Interfaces
{
    interface IPedido
    {
        void EfetuarPedido(Carrinho carrinho, DetalhePagamento detalhePagamento, bool notificarClienteEmail,
            bool notificarClienteSms);
    }
}
