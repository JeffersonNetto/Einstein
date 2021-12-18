namespace Einstein.Core.Models
{
    public class Pessoa : Comum<Guid>
    {        
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int? CEP { get; set; }
        public string Logradouro { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }        
        public Guid UserId { get; set; }        
    }
}