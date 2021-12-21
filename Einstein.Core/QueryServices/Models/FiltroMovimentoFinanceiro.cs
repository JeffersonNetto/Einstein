using Einstein.Core.Enums;

namespace Einstein.Core.QueryServices.Models
{
    public class FiltroMovimentoFinanceiro
    {
        public short? FormaPagamentoId { get; set; }
        public DateTime? DataMovimentoDe { get; set; }
        public DateTime? DataMovimentoAte { get; set; }
        public decimal? ValorMovimentoDe { get; set; }
        public decimal? ValorMovimentoAte { get; set; }
        public TipoMovimentoFinanceiro? TipoMovimentoFinanceiro { get; set; } 
    }
}
