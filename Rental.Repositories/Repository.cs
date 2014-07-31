using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Rental.Interfaces;

namespace Rental.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        public virtual int Count
        {
            get { return _dbSet.Count(); }
        }

        public virtual IQueryable<TEntity> All()
        {
            return _dbSet.AsQueryable();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties
                .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            var skipCount = index * size;
            var resetSet = filter != null ? _dbSet.Where(filter).AsQueryable() : _dbSet.AsQueryable();
            
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();

            return resetSet.AsQueryable();
        }

        public bool Contains(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Count(predicate) > 0;
        }

        public virtual TEntity Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        
        public virtual TEntity Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new NoNullAllowedException();
            }

            var newEntity = _dbSet.Add(entity);
            return newEntity;
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            
            if (entity == null)
            {
                return;
            }

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new NoNullAllowedException();
            }

            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }
        
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = Filter(predicate);
            foreach (var entity in entitiesToDelete)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            }            
        }
        
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new NoNullAllowedException();
            }

            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}