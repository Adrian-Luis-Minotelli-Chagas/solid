namespace Daycoval.Solid.Domain.Enums
{
    public class Produto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorImposto { get; set; }
        public TipoProduto TipoProduto { get; set; }
        
    }
}