namespace Einstein.Core.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task Adicionar(TEntity entity);
    }
}
