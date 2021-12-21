namespace Einstein.Core.Models
{
    public class ProfessorConfiguracao : Comum<int>
    {
        public Guid ProfessorId { get; set; }
        public short CursoId { get; set; }
        public short DisciplinaId { get; set; }        
        public short ModalidadeId { get; set; }        
        public virtual Professor Professor { get; set; } = default!;        
        public virtual Curso Curso { get; set; } = default!;
        public virtual Disciplina Disciplina { get; set; } = default!;        
        public virtual Modalidade Modalidade { get; set; } = default!;     
        public virtual ICollection<ProfessorConfiguracaoHorario> ProfessorConfiguracaoHorario { get; set; } = default!;
    }
}
