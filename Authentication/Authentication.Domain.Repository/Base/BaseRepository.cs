using Authentication.Common.Entity;
using Authentication.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Base
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AuthenticationContext context;

        DbSet<TEntity> dbSet;

        public BaseRepository(AuthenticationContext _context)
        {
            context = _context;
            dbSet = context.Set<TEntity>();
        }

        public async Task InsertAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Insert(TEntity entitiy)
        {
            dbSet.Add(entitiy);
        }

        public async Task InsertAsync(TEntity entitiy)
        {
            await dbSet.AddAsync(entitiy);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return this.dbSet.Where(expression).FirstOrDefault();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return this.dbSet.FirstOrDefaultAsync(expression);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression)
        {
            return this.dbSet.Where(expression).AsEnumerable();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, string include)
        {
            return this.dbSet.Where(expression).Include(include).AsEnumerable();
        }

        public TEntity GetInclude(Expression<Func<TEntity, bool>> expression, string include)
        {
            return this.dbSet.Include(include).FirstOrDefault(expression);
        }

        public IEnumerable<TEntity> GetPage(Expression<Func<TEntity, bool>> expression, int? pageIndex, int? pageSize, out int totalCount)
        {
            IEnumerable<TEntity> entityList = null;

            var query = this.dbSet.Where(expression).AsQueryable();

            int rowsCount = query.Count();

            int skipCount = 0;

            if (pageSize == null || pageSize <= 0)
            {
                pageSize = rowsCount;
            }

            if (pageIndex == null || pageIndex <= 0)
            {
                pageIndex = 1;
            }


            skipCount = (pageIndex.Value - 1) * pageSize.Value;
            entityList = query.OrderBy(x => x.Id).Skip(skipCount).Take(pageSize.Value);


            totalCount = rowsCount;

            return entityList;
        }

        public bool Delete(TEntity entitiy)
        {
            var removed = false;
            if (entitiy != null)
            {
                removed = true;
                dbSet.Remove(entitiy);
            }
            return removed;
        }

        public bool Delete(long id)
        {
            var removed = false;
            var entity = this.Get(x => x.Id == id);
            if (entity != null)
            {
                removed = true;
                dbSet.Remove(entity);
            }
            return removed;
        }

        public bool DeleteAll(IEnumerable<TEntity> entities)
        {
            var removed = false;
            if (entities != null)
            {
                removed = true;
                dbSet.RemoveRange(entities);
            }
            return removed;
        }
    }
}
