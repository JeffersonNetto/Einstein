using Einstein.Core.Enums;

namespace Einstein.Core.Models
{
    public class MovimentoFinanceiro : Comum<long>
    {
        public TipoMovimentoFinanceiro TipoMovimentoFinanceiro { get; set; }
        public DateTime DataHora { get; set; }
        public short DiaVencimento { get; set; }
        public short NrParcelas { get; set; }
        public decimal ValorEntrada { get; set; } = 0;
        public decimal ValorDesconto { get; set; } = 0;
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; } = 0;
        public short FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; } = default!;
        public virtual ICollection<Parcela> Parcela { get; set; } = default!;
    }
}
