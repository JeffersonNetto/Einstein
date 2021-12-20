using Einstein.Core.Models;
using Einstein.Core.Repositories;

namespace Einstein.Infra.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
