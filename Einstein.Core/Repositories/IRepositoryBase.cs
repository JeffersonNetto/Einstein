namespace Einstein.Core.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        Task<bool> Exists<T>(T id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById<T>(T id);
        void Remove(TEntity obj);
        void Update(TEntity obj);
    }
}
