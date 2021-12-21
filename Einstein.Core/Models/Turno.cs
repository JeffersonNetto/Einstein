namespace Einstein.Core.Models
{
    public class Turno : Comum<short>
    {
        public string Nome { get; set; } = default!;
        public virtual ICollection<Curso> Curso { get; set; } = default!;
        public virtual ICollection<HorarioConfiguracao> HorarioConfiguracao { get; set; } = default!;
    }
}
