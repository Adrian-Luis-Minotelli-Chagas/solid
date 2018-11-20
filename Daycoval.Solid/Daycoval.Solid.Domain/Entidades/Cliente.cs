namespace Daycoval.Solid.Domain.Enums
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public bool EmailValido()
        {
            return !string.IsNullOrWhiteSpace(Email);
        }

        public bool CelularValido()
        {
            return !string.IsNullOrWhiteSpace(Celular);
        }
    }
}