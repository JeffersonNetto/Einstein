namespace Einstein.Core.Models
{
    public class Disciplina : Comum<short>
    {
        public string Nome { get; set; } = default!;
        public virtual ICollection<Professor> Professor { get; set; } = default!;
    }
}
