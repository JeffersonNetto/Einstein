namespace Einstein.Core.Models
{
    public class Aluno : PessoaFisica
    {                          
        public int? AnoConclusaoEnsinoMedio { get; set; }
        public bool JaRealizouEnem { get; set; }
        public double? MediaGeralEnem { get; set; }
        public double? NotaRedacaoEnem { get; set; }
        public double? NotaExatasEnem { get; set; }
        public double? NotaCienciasDaNaturezaEnem { get; set; }
        public double? NotaHumanasEnem { get; set; }
        public double? NotaLinguagensEnem { get; set; }                        
        public bool EstaEmpregado { get; set; }                
        public bool ExAluno { get; set; }
    }
}
