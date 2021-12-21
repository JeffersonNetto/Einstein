namespace Einstein.Core.Models
{
    public class ProfessorFrequencia : Comum<long>
    {
        public int ProfessorConfiguracaoHorarioId { get; set; }
        public bool Presente { get; set; }
        public short? MotivoAusenciaId { get; set; }
        public string? Observacoes { get; set; }
    }
}
