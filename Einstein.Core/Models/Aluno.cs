namespace Einstein.Core.Models
{
    public class Aluno : PessoaFisica
    {
        public int? AnoConclusaoEnsinoMedio { get; set; }
        public bool JaRealizouEnem { get; set; }
        public float? MediaGeralEnem { get; set; }
        public float? NotaRedacaoEnem { get; set; }
        public float? NotaExatasEnem { get; set; }
        public float? NotaCienciasDaNaturezaEnem { get; set; }
        public float? NotaHumanasEnem { get; set; }
        public float? NotaLinguagensEnem { get; set; }
        public bool EstaEmpregado { get; set; }
        public bool ExAluno { get; set; }
        public virtual ICollection<Curso> Curso { get; set; } = default!;
    }
}
