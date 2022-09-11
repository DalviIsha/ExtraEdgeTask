using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Domain.Interfaces.Repositories.Common;
using WebApplication1.Infrastructure.Context;

namespace WebApplication1.Infrastructure.Repositories.Common
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity>
        where TEntity : class
    {
        protected WriteWebApplication1MSContext Context { get; }

        public QueryRepository(WriteWebApplication1MSContext context)
        {
            Context = context;
            Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        {
            return await Context.Set<TEntity>().Where(predicate)?.ToListAsync(token);
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate, token);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> Find()
        {
            return Context.Set<TEntity>();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken token = default)
        {
            return predicate is null ? await Context.Set<TEntity>().CountAsync(token) : await Context.Set<TEntity>().CountAsync(predicate, token);
        }

        public async Task<bool> IsRecordExist(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        {
            return await Context.Set<TEntity>().AnyAsync(predicate, token);
        }
    }
}