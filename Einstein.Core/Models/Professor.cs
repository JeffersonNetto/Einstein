namespace Einstein.Core.Models
{
    public class Professor : PessoaFisica
    {                
        public string Graduacao { get; set; }        
        public bool TrabalhaEmOutroLocal { get; set; }
        public string LocalOndeTrabalha { get; set; }
        public float CargaHorariaSemanal { get; set; }        
    }
}
