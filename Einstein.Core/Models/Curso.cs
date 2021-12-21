namespace Einstein.Core.Models
{
    public class Curso : Comum<short>
    {
        public string Nome { get; set; } = default!;
        public virtual ICollection<Turno> Turno { get; set; } = default!;
        public virtual ICollection<Modalidade> Modalidade { get; set; } = default!;
        public virtual ICollection<Professor> Professor { get; set;} = default!;
        public virtual ICollection<Aluno> Aluno { get; set; } = default!;
    }
}
