using System;
using System.Linq;
using System.Linq.Expressions;
using Rental.Models.Entities.Base;

namespace Rental.Interfaces
{
    public interface IRepository<TEntity, in TKey> where TEntity : Entity
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(TKey id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
