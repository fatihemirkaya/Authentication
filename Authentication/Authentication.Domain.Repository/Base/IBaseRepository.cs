using Authentication.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Authentication.Domain.Repository.Base
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        public Task InsertAsync(IEnumerable<TEntity> entities);

        public void Insert(IEnumerable<TEntity> entities);

        public void Insert(TEntity entitiy);

        public Task InsertAsync(TEntity entitiy);

        public TEntity Get(Expression<Func<TEntity, bool>> expression);

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression);

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, string include);

        public IEnumerable<TEntity> GetPage(Expression<Func<TEntity, bool>> expression, int? pageIndex, int? pageSize, out int totalCount);

        public bool Delete(TEntity entitiy);

        public bool DeleteAll(IEnumerable<TEntity> entities);

        public bool Delete(long id);

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);

        TEntity GetInclude(Expression<Func<TEntity, bool>> expression, string include);
    }
}
