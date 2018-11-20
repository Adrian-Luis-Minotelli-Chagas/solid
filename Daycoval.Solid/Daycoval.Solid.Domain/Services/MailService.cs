using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Daycoval.Solid.Domain.Services
{
    class MailService : IMail
    {
        public void notificarClienteEmail(Cliente cliente, bool notificarClienteEmail)
        {
            if (cliente.EmailValido() && notificarClienteEmail)
            {
                using (var msg = new MailMessage("tiago.dantas@bancodaycoval.com.br", cliente.Email))
                using (var smtp = new SmtpClient("servidor.smtp"))
                {
                    msg.Subject = "Dados da sua compra";
                    msg.Body = $"Obrigado por efetuar sua compra conosco.";

                    smtp.Send(msg);
                }
            }
        }
    }
}
