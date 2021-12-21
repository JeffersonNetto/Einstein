namespace Einstein.Core.Models
{
    public class HorarioConfiguracao : Comum<short>
    {        
        public string Descricao { get; set; } = default!;
        public DayOfWeek DiaDaSemana { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public short TurnoId { get; set; }
        public virtual Turno Turno { get; set; } = default!;
        public virtual ICollection<ProfessorConfiguracaoHorario> ProfessorConfiguracaoHorario { get; set; } = default!;
    }
}
