namespace Einstein.Core.Models
{
    public class Comum<T>
    {        
        public T Id { get; set; } = default!;
        public string IP { get; set; } = "localhost";
        public bool Ativo { get; set; } = true;
        public Guid UsuarioCriacaoId { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public Guid? UsuarioAlteracaoId { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
