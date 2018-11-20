using Daycoval.Solid.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Interfaces
{
    public interface IMail
    {
        void notificarClienteEmail(Cliente cliente, bool notificarClienteEmail);
    }
}
