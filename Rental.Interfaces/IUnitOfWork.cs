using System;

namespace Rental.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Commit();
        void Rollback();
    }
}
