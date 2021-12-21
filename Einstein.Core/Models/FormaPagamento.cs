namespace Einstein.Core.Models
{
    public class FormaPagamento : Comum<short>
    {
        public string Descricao { get; set; } = default!;
        public ICollection<MovimentoFinanceiro> MovimentoFinanceiro { get; set; } = default!;
    }
}
