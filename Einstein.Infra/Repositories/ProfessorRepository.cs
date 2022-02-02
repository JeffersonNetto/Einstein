using Einstein.Core.Models;
using Einstein.Core.Repositories;
using MongoDB.Driver;

namespace Einstein.Infra.Repositories
{
    public class ProfessorRepository : RepositoryBase<Professor>, IProfessorRepository
    {
        public ProfessorRepository(IMongoDatabase database) : base(database, nameof(Professor)) { }

        public async Task<Professor> GetById(Guid id)
        {
            return await collection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
