using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rental.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int Count { get; }

        IQueryable<TEntity> All();

        TEntity GetById(object id);
        
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, 
            out int total, int index = 0, int size = 50);

        bool Contains(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(params object[] keys);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        TEntity Create(TEntity entity);
        
        void Update(TEntity entity);

        void Delete(TEntity entity);
        
        void Delete(object id);

        void Delete(Expression<Func<TEntity, bool>> predicate);
    }
}
