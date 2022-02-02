using Einstein.Core.Models;

namespace Einstein.Core.Repositories
{
    public interface IAlunoRepository : IRepositoryBase<Aluno>
    {        
        Task<Aluno> GetById(Guid id);
    }
}
