using Einstein.Core.Repositories;
using MongoDB.Driver;

namespace Einstein.Infra.Repositories
{    
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> collection;
        public RepositoryBase(IMongoDatabase database, string collectionName)
        {
            collection = database.GetCollection<TEntity>(collectionName);
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await collection.Find(_ => true).ToListAsync();
        }
        public async Task Adicionar(TEntity entity)
        {
            await collection.InsertOneAsync(entity);
        }        
    }
}
