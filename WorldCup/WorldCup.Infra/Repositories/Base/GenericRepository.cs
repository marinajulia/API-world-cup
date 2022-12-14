using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WorldCup.Infra.Data;
using WorldCup.SharedKernel.Notification;
using WorldCup.SharedKernel.Helper;
using WorldCup.SharedKernel.Enuns.UserMessages;

namespace WorldCup.Infra.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly INotification _notification;

        public GenericRepository(ApplicationContext context, INotification notification)
        {
            _dbSet = context.Set<T>();
            _notification = notification;
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.CountAsync(expression);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstAsync(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null)
                return _notification.AddWithReturn<T>(UserMessagesEnum.notFound.GetDescription());
            return entity;
        }

        public async Task<System.Collections.Generic.List<T>> GetDataAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int? skip = null, int? take = null)
        {
            var query = _dbSet.AsQueryable();
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }
    }
}
