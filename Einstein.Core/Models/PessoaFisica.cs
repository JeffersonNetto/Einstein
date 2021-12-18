namespace Einstein.Core.Models
{
    public class PessoaFisica : Pessoa
    {         
        public string Nome { get; set; }        
        public string Sobrenome { get; set; }        
        public int CPF { get; set; }        
        public string RG { get; set; }        
        public DateTime DataNascimento { get; set; }
    }
}
