namespace Einstein.Core.Models
{
    public class Professor : PessoaFisica
    {                
        public string? Graduacao { get; set; }        
        public bool TrabalhaEmOutroLocal { get; set; }
        public string? LocalOndeTrabalha { get; set; }
        public float CargaHorariaSemanal { get; set; }    
        public decimal ValorHoraAula { get; set; }        
        public virtual ICollection<Curso> Curso { get; set; } = default!;
        public virtual ICollection<Disciplina> Disciplina { get; set;} = default!;
        public virtual ICollection<ProfessorConfiguracao> ProfessorConfiguracao { get; set; } = default!;
    }
}
