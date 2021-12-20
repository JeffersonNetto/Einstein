namespace Einstein.Core.Models
{
    public class Professor : PessoaFisica
    {                
        public string? Graduacao { get; set; }        
        public bool TrabalhaEmOutroLocal { get; set; }
        public string? LocalOndeTrabalha { get; set; }
        public float CargaHorariaSemanal { get; set; }    
        public ICollection<ProfessorHorario>? Horario { get; set; }
    }

    public class ProfessorHorario
    {
        public DayOfWeek DiaDaSemana { get; set; }

        public ICollection<ProfessorHorarioItem> Horarios { get; set; } = default!;
    }

    public class ProfessorHorarioItem
    {
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
    }
}
