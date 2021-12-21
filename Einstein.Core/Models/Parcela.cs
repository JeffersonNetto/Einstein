namespace Einstein.Core.Models
{
    public class Parcela : Comum<long>
    {
        public short Numero { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorPago { get; set; } = 0;
        public decimal ValorDesconto { get; set; } = 0;
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public virtual MovimentoFinanceiro MovimentoFinanceiro { get; set; } = default!;
    }
}
