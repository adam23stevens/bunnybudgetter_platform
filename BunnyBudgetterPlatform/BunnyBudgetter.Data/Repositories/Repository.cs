using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BunnyBudgetterPlatform.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BunnyBudgetter.Data.Repositories
{
    public class Repository : IRepository
    {
        private readonly BunnyBudgetterPlatformContext _context;

        public Repository(BunnyBudgetterPlatformContext context)
        {
            _context = context;
        }

        public async Task AddEntity<T>(T entity) where T : class
        {
            if (entity != null)
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetAllWhere<T>(Expression<Func<T, bool>> qry) where T : class
        {
            return _context.Set<T>().Where(qry);
        }

        public IQueryable<T> GetAllWhereWithIncludes<T>(Expression<Func<T, bool>> qry, params Expression<Func<T, object>>[] includes) where T : class
        {
            var queryable = _context.Set<T>().AsQueryable();
            return includes.Aggregate(
                queryable,
                (current, include) => current.Include(include))
                .Where(qry);
        }

        public IQueryable<T> GetAllWithIncludes<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            var queryable = _context.Set<T>().AsQueryable();
            return includes.Aggregate(queryable, (current, include) => current.Include(include));
        }

        public async Task<T> GetEntityById<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateEntity<T>(T obj) where T : class
        {
            _context.Update<T>(obj);
            await _context.SaveChangesAsync();
        }
    }
}
