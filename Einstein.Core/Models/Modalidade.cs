namespace Einstein.Core.Models
{
    public class Modalidade : Comum<short>
    {
        public string Nome { get; set; } = default!;
        public virtual ICollection<Curso> Curso { get; set; } = default!;
    }
}
