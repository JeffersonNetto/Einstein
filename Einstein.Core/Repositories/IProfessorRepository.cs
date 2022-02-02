using Einstein.Core.Models;

namespace Einstein.Core.Repositories
{
    public interface IProfessorRepository : IRepositoryBase<Professor>
    {
        Task<Professor> GetById(Guid id);
    }
}
