namespace Einstein.Core.Models
{
    public class ProfessorConfiguracaoHorario : Comum<int>
    {
        public int ProfessorConfiguracaoId { get; set; }
        public short HorarioConfiguracaoId { get; set; }
        public virtual ProfessorConfiguracao ProfessorConfiguracao { get; set; } = default!;
        public virtual HorarioConfiguracao HorarioConfiguracao { get; set; } = default!;
    }
}
