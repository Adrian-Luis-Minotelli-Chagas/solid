using Daycoval.Solid.Domain.Enums;
using Daycoval.Solid.Domain.Interfaces;

namespace Daycoval.Solid.Domain.Services
{
    public class SmsService : ISms
    {
        public string Celular { get; set; }
        public string Mensagem { get; set; }

        public void NotificarClienteSms(Cliente cliente, bool notificarClienteSms)
        {

            if (cliente.CelularValido() && notificarClienteSms)
            {
                Mensagem = "Obrigado por sua compra";
                Celular = cliente.Celular;

                this.EnviarSms();
            }
        }

        private void EnviarSms()
        {
            //Este método não precisa ser implementado.
        }
    }
}