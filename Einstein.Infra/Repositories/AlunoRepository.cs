using Einstein.Core.Models;
using Einstein.Core.Repositories;
using MongoDB.Driver;

namespace Einstein.Infra.Repositories
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAlunoRepository
    {                
        public AlunoRepository(IMongoDatabase database) : base(database, nameof(Aluno)) { }
        public async Task<Aluno> GetById(Guid id)
        {
            return await collection.Find(a => a.Id == id).FirstOrDefaultAsync();
        }
    }
}
