using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Core
{
    public interface IRepository<TEntity>

    {

        IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");

        TEntity GetById(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

    }
}
