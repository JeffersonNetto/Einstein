namespace Einstein.Core.Models
{
    public class PessoaFisica : Pessoa
    {
        public string Nome { get; set; } = default!;   
        public string Sobrenome { get; set; } = default!;
        public string CPF { get; set; } = default!;
        public string? RG { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
