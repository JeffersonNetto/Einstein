using Einstein.Core.Models;
using Einstein.Core.Repositories;

namespace Einstein.Infra.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDbContext context) : base(context) { }
    }
}
