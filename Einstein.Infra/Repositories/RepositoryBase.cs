using Einstein.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Einstein.Infra.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context) =>
            _context = context;

        public async Task Add(TEntity obj) =>
            await _context.Set<TEntity>().AddAsync(obj);

        public async Task<bool> Exists<T>(T id) =>
            await _context.Set<TEntity>().FindAsync(id) != null;

        public async Task<IEnumerable<TEntity>> GetAll() =>
            await _context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

        public async Task<TEntity?> GetById<T>(T id) =>
            await _context.Set<TEntity>().FindAsync(id);

        public void Remove(TEntity obj) =>
            _context.Set<TEntity>().Remove(obj);

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property("DataCriacao").IsModified = false;
            _context.Entry(obj).Property("UsuarioCriacaoId").IsModified = false;
        }

        public void Dispose() => _context?.Dispose();
    }
}
